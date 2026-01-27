# Pencil.dev Workflow Guide
## (Enterprise Frontend Design-in-Code with AI)

## Purpose
本文件定義如何在本專案中使用 **Pencil.dev** 作為
「設計即程式碼（Design as Code）」的 UI 設計與元件產出工具，
並確保所有設計與生成結果 **嚴格遵循既有前端規範**。

Pencil.dev 在此專案中扮演的角色：
- UI 設計畫布（取代 Figma）
- AI 驅動 UI 元件產生器
- 與 Git / Codebase 同步的設計資產來源

---

## Core Principles

1. **Design follows Architecture**
   - UI 設計必須符合 Layer-based 架構
   - 設計輸出必須能直接對應到 Vue Component

2. **Design is Code-Ready**
   - 所有 UI 設計都假設會轉成 Vue 3 + Element Plus Component
   - 禁止產生無法實作或與實作脫節的設計

3. **AI is a Junior-but-Fast UI Engineer**
   - AI 必須被明確告知專案技術棧與限制
   - Prompt 必須具備「規範、責任、輸出格式」

---

## Where Pencil.dev Fits in the Project

Idea / Requirement
↓
Pencil.dev (AI Canvas)
↓
UI Structure & Layout (Design)
↓
Vue Component (Element Plus + SCSS)
↓
Integrate with API / Store / Query


Pencil.dev **只負責 UI 結構與視覺設計**
- ❌ 不負責商業邏輯
- ❌ 不負責 API 實作
- ❌ 不負責 State 管理實作
- ✅ 產出「可轉為 Component 的設計」

---

## Design Asset Strategy

### What to Design in Pencil.dev
- Page Layout（頁面結構）
- Form Layout（表單欄位、群組、排列）
- Data Table UI（欄位、操作區、分頁位置）
- Modal / Dialog UI
- Empty / Error / Loading States
- Role-based UI Variants（不同角色看到的畫面）

### What NOT to Design in Pencil.dev
- API URL
- Business rules
- Permission logic implementation
- Data mapping

---

## Mapping Pencil Design → Code

| Pencil Design Element | Vue / Element Plus |
|----------------------|--------------------|
| Page                 | `pages/*.vue`      |
| Layout               | `layouts/*.vue`   |
| Form                 | `<el-form>`       |
| Input                | `<el-input>` / `<el-select>` |
| Table                | `<el-table>`      |
| Dialog               | `<el-dialog>`     |
| Pagination           | `<el-pagination>` |
| Button               | `<el-button>`     |

---

# 🧠 AI Prompting Rules (CRITICAL)

## Every Prompt MUST Include

1. **Tech Stack Context**
2. **Component Responsibility**
3. **Design Constraints**
4. **Expected Output**

If any of these are missing，AI 產出會偏離企業規範。