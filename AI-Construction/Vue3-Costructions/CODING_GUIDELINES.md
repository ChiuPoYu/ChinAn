# Frontend Coding Guidelines (Vue 3 + TS, Enterprise)

## Required Stack
- Vue 3 + Vite SPA
- TypeScript mandatory
- Element Plus as UI library
- SCSS for styles (with minimal global scope)
- Pinia for client state
- TanStack Query (Vue Query) for server state
- Zod for form validation (and runtime validation when needed)
- Testing: Vitest + Vue Testing Library + Playwright
- Lint/Format: ESLint + Prettier
- Husky + lint-staged enabled (pre-commit)

---

## TypeScript Rules
- noImplicitAny / strict recommended
- avoid `any`; use unknown + narrowing when needed
- define shared types in `src/types/`

---

## SCSS Rules
- Global styles are limited to:
  - tokens/variables
  - reset/base
  - Element Plus theme overrides
- Component styles should avoid polluting global namespace:
  - prefer scoped styles or SCSS modules approach
- Naming consistency required (BEM if using global classes)

---

## Vue Component Rules
- Prefer Composition API (`<script setup lang="ts">`)
- Keep components small:
  - pages: compose
  - components: reusable, focused
- No direct axios calls inside components; use queries/api modules

---

## Pinia Rules (Client State)
- auth.store.ts:
  - user, role, isAuthenticated
  - methods: initFromMe(), logout()
- ui.store.ts:
  - theme, locale, layout flags
- Never store server lists in Pinia (use Vue Query)

---

## TanStack Query Rules (Server State)
- Query keys must be stable and consistent:
  - list: ['devices', { page, pageSize, keyword }]
  - detail: ['device', id]
- On mutation success:
  - invalidate related queries (e.g. ['devices'])
- Must handle pagination from backend ListResponse

---

## Zod Validation Rules
### Required
- Every form must have a Zod schema in `src/schemas/`
- Validation must run at submit time (required)
- Optional: validate on blur/change for better UX

### Submit Flow (Standard)
1) user clicks submit
2) validate using Zod schema
3) if invalid -> show field errors, do NOT call API
4) if valid -> call mutation
5) handle API errors:
   - field errors -> set on fields
   - general errors -> toast/dialog

### Runtime Parse (Optional but Recommended)
- For critical responses, parse with Zod to guard backend contract changes.

---

## Error Display Rules
- Field errors: show near inputs (Element Plus form item)
- General errors:
  - toast (non-blocking)
  - dialog (blocking / destructive action confirmations)
- 401:
  - redirect to login + clear auth state
- 403:
  - show "no permission" page or toast + route guard
- 404:
  - show not found page
- 5xx:
  - show generic error + log to console (optional monitoring)

---

## Router & RBAC
- All routes must define meta:
  - requiresAuth: boolean
  - rolesAllowed: ['customer','admin'] etc.
- Router guard checks authStore.role
- UI must also hide/disable unauthorized actions

---

## ESLint & Prettier
- ESLint: code quality + Vue/TS rules
- Prettier: formatting only
- Use recommended configs to avoid conflicts:
  - eslint-config-prettier to disable formatting rules in ESLint
  - eslint-plugin-prettier optional (team preference)

---

## Husky + lint-staged (Required)
### What it does
- pre-commit hook runs:
  - prettier --write on staged files
  - eslint --fix on staged files
- commit fails if ESLint errors remain

### Why required
- ensures consistent formatting & quality before code enters repo
- reduces CI failures

---

## Testing Strategy (Required)
### Unit (Vitest)
- utils, permission helpers, error mapping, env resolver

### Component (Vue Testing Library)
- complex forms, critical reusable components

### E2E (Playwright)
- login flow
- RBAC access control:
  - guest cannot access protected routes
  - customer cannot access admin routes
  - admin can perform CRUD
- pagination list flows

---

## Git Commit Messages
- developer writes commit messages manually
- no enforced conventional commits