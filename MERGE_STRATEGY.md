# Git 合併策略說明

## 保護檔案設定

本專案已設定 Git 合併策略，保護以下檔案在分支合併時不被覆蓋：

### 受保護的檔案：
- `README.md` - 專案說明文件
- `.github/workflows/*.yml` - GitHub Actions 工作流程檔案

### 合併策略：
- 使用 `merge=ours` 策略
- 合併時會保留**當前分支**的版本
- 不會被其他分支的版本覆蓋

## 分支合併流程

### 1. feature → develop
- README.md 和 workflows 保持 develop 分支的版本
- 其他檔案正常合併

### 2. develop → main
- README.md 和 workflows 保持 main 分支的版本
- 其他檔案正常合併

### 3. 手動合併特定檔案
如果需要更新受保護的檔案，可以手動執行：
```bash
# 合併特定檔案
git checkout <target-branch>
git checkout <source-branch> -- README.md
git commit -m "Update README.md from source branch"
```

## 注意事項

1. **首次設定**：需要將 `.gitattributes` 檔案提交到所有分支
2. **團隊協作**：所有團隊成員都需要拉取最新的 `.gitattributes` 配置
3. **手動更新**：受保護的檔案需要手動更新，不會自動合併

## 驗證設定

檢查合併策略是否生效：
```bash
git config --get merge.ours.driver
# 應該回傳 "true"
```
