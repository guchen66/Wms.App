# WMS项目重命名步骤文档

## 概述
本项目原名为 `Kstopa.Lx.*`，需要将其重命名为 `Wms.*` 格式。

### 重命名映射表

| 当前名称 | 新名称 | 说明 |
|---------|--------|------|
| Kstopa.Lx.WMS | Wms.App | 主应用程序 |
| Kstopa.Lx.Core | Wms.Core | 核心工具类 |
| Kstopa.Lx.Controls | Wms.Controls | 控件和视图模块 |
| Kstopa.Lx.Admin | Wms.Admin | 管理服务层 |
| Kstopa.Lx.SugarDb | Wms.Data | 数据库层（注意：不是Wms.SugarDb） |
| Kstopa.Lx.Communication | Wms.Communication | 通信模块 |

### 关键注意事项

1. **替换顺序很重要**：必须按最长匹配优先原则，先替换完整的项目命名空间
2. **XAML文件特殊处理**：需要同时更新 `clr-namespace:` 和 `assembly=` 两部分
3. **物理文件重命名**：必须在内容替换完成后进行
4. **解决方案文件**：需要更新项目名称和路径引用

---

## 步骤1：全局替换 Kstopa.Lx.SugarDb → Wms.Data

**命令：**
```powershell
Get-ChildItem -Path "E:\TraeProject\Kstopa.Lx.WMS" -Recurse -Include "*.cs","*.xaml","*.csproj","*.sln" | 
    ForEach-Object {
        $content = Get-Content $_.FullName -Raw -Encoding UTF8
        $content = $content -replace 'Kstopa\.Lx\.SugarDb', 'Wms.Data'
        Set-Content $_.FullName -Value $content -NoNewline -Encoding UTF8
    }
```

**说明：**
- 替换范围：所有 `.cs`、`.xaml`、`.csproj`、`.sln` 文件
- 这一步必须最先执行，因为 `Kstopa.Lx.SugarDb` 是最长的命名空间之一
- 如果先替换 `Kstopa.Lx.Core` 等，可能会影响后续匹配

---

## 步骤2：全局替换 Kstopa.Lx.WMS → Wms.App

**命令：**
```powershell
Get-ChildItem -Path "E:\TraeProject\Kstopa.Lx.WMS" -Recurse -Include "*.cs","*.xaml","*.csproj","*.sln" | 
    ForEach-Object {
        $content = Get-Content $_.FullName -Raw -Encoding UTF8
        $content = $content -replace 'Kstopa\.Lx\.WMS', 'Wms.App'
        Set-Content $_.FullName -Value $content -NoNewline -Encoding UTF8
    }
```

**说明：**
- 注意区分大小写：`WMS` 全大写
- 这是主应用程序的命名空间

---

## 步骤3：全局替换 Kstopa.Lx.Communication → Wms.Communication

**命令：**
```powershell
Get-ChildItem -Path "E:\TraeProject\Kstopa.Lx.WMS" -Recurse -Include "*.cs","*.xaml","*.csproj","*.sln" | 
    ForEach-Object {
        $content = Get-Content $_.FullName -Raw -Encoding UTF8
        $content = $content -replace 'Kstopa\.Lx\.Communication', 'Wms.Communication'
        Set-Content $_.FullName -Value $content -NoNewline -Encoding UTF8
    }
```

---

## 步骤4：全局替换 Kstopa.Lx.Controls → Wms.Controls

**命令：**
```powershell
Get-ChildItem -Path "E:\TraeProject\Kstopa.Lx.WMS" -Recurse -Include "*.cs","*.xaml","*.csproj","*.sln" | 
    ForEach-Object {
        $content = Get-Content $_.FullName -Raw -Encoding UTF8
        $content = $content -replace 'Kstopa\.Lx\.Controls', 'Wms.Controls'
        Set-Content $_.FullName -Value $content -NoNewline -Encoding UTF8
    }
```

---

## 步骤5：全局替换 Kstopa.Lx.Admin → Wms.Admin

**命令：**
```powershell
Get-ChildItem -Path "E:\TraeProject\Kstopa.Lx.WMS" -Recurse -Include "*.cs","*.xaml","*.csproj","*.sln" | 
    ForEach-Object {
        $content = Get-Content $_.FullName -Raw -Encoding UTF8
        $content = $content -replace 'Kstopa\.Lx\.Admin', 'Wms.Admin'
        Set-Content $_.FullName -Value $content -NoNewline -Encoding UTF8
    }
```

---

## 步骤6：全局替换 Kstopa.Lx.Core → Wms.Core

**命令：**
```powershell
Get-ChildItem -Path "E:\TraeProject\Kstopa.Lx.WMS" -Recurse -Include "*.cs","*.xaml","*.csproj","*.sln" | 
    ForEach-Object {
        $content = Get-Content $_.FullName -Raw -Encoding UTF8
        $content = $content -replace 'Kstopa\.Lx\.Core', 'Wms.Core'
        Set-Content $_.FullName -Value $content -NoNewline -Encoding UTF8
    }
```

**说明：**
- 这一步必须最后执行，因为 `Kstopa.Lx.Core` 是最短的前缀
- 如果先执行，可能会误替换其他项目中包含 `Kstopa.Lx.Core` 的部分

---

## 步骤7：清理剩余的 Kstopa.Lx 引用

**检查命令：**
```powershell
Get-ChildItem -Path "E:\TraeProject\Kstopa.Lx.WMS" -Recurse -Include "*.cs","*.xaml","*.csproj","*.sln" | 
    Select-String -Pattern 'Kstopa' | 
    Select-Object -Property Path, LineNumber, Line
```

**如果有剩余，手动处理。通常这一步应该没有剩余。**

---

## 步骤8：更新解决方案文件 (.sln)

**手动编辑 `Kstopa.Lx.WMS.sln` 文件：**

1. 更新项目名称
2. 更新项目路径引用

**示例改动：**
```
旧: Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Kstopa.Lx.WMS", "Kstopa.Lx.WMS\Kstopa.Lx.WMS.csproj", "{GUID}"
新: Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Wms.App", "Wms.App\Wms.App.csproj", "{GUID}"
```

---

## 步骤9：重命名物理文件夹和项目文件

**按顺序执行以下重命名：**

```powershell
# 1. 重命名主应用文件夹
Rename-Item -Path "E:\TraeProject\Kstopa.Lx.WMS\Kstopa.Lx.WMS" -NewName "Wms.App"

# 2. 重命名 Controls 文件夹
Rename-Item -Path "E:\TraeProject\Kstopa.Lx.WMS\Kstopa.Lx.Controls" -NewName "Wms.Controls"

# 3. 重命名 Core 文件夹
Rename-Item -Path "E:\TraeProject\Kstopa.Lx.WMS\Kstopa.Lx.Core" -NewName "Wms.Core"

# 4. 重命名 SugarDb 文件夹
Rename-Item -Path "E:\TraeProject\Kstopa.Lx.WMS\Kstopa.Lx.SugarDb" -NewName "Wms.Data"

# 5. 重命名 Admin 文件夹
Rename-Item -Path "E:\TraeProject\Kstopa.Lx.WMS\Kstopa.Lx.Admin" -NewName "Wms.Admin"

# 6. 重命名 Communication 文件夹
Rename-Item -Path "E:\TraeProject\Kstopa.Lx.WMS\Kstopa.Lx.Communication" -NewName "Wms.Communication"

# 7. 重命名项目文件
Rename-Item -Path "E:\TraeProject\Kstopa.Lx.WMS\Wms.App\Kstopa.Lx.WMS.csproj" -NewName "Wms.App.csproj"
Rename-Item -Path "E:\TraeProject\Kstopa.Lx.WMS\Wms.Controls\Kstopa.Lx.Controls.csproj" -NewName "Wms.Controls.csproj"
Rename-Item -Path "E:\TraeProject\Kstopa.Lx.WMS\Wms.Core\Kstopa.Lx.Core.csproj" -NewName "Wms.Core.csproj"
Rename-Item -Path "E:\TraeProject\Kstopa.Lx.WMS\Wms.Data\Kstopa.Lx.SugarDb.csproj" -NewName "Wms.Data.csproj"
Rename-Item -Path "E:\TraeProject\Kstopa.Lx.WMS\Wms.Admin\Kstopa.Lx.Admin.csproj" -NewName "Wms.Admin.csproj"
Rename-Item -Path "E:\TraeProject\Kstopa.Lx.WMS\Wms.Communication\Kstopa.Lx.Communication.csproj" -NewName "Wms.Communication.csproj"

# 8. 重命名解决方案文件
Rename-Item -Path "E:\TraeProject\Kstopa.Lx.WMS\Kstopa.Lx.WMS.sln" -NewName "Wms.sln"
```

---

## 步骤10：更新项目文件中的相对路径引用

每个 `.csproj` 文件中的 `ProjectReference` 需要更新路径：

**示例改动：**
```xml
旧: <ProjectReference Include="..\Kstopa.Lx.Admin\Kstopa.Lx.Admin.csproj" />
新: <ProjectReference Include="..\Wms.Admin\Wms.Admin.csproj" />
```

---

## 步骤11：构建验证

```powershell
cd E:\TraeProject\Kstopa.Lx.WMS
dotnet build Wms.sln
```

---

## 常见问题及解决方案

### 问题1：XAML文件中的 clr-namespace 未更新

**现象：** 运行时出现 `XamlParseException`，提示找不到命名空间

**解决方案：**
检查 XAML 文件中的 xmlns 声明：
```xml
旧: xmlns:core="clr-namespace:Kstopa.Lx.Core.Common;assembly=Kstopa.Lx.Core"
新: xmlns:core="clr-namespace:Wms.Core.Common;assembly=Wms.Core"
```

### 问题2：项目引用路径错误

**现象：** 构建时提示找不到项目文件

**解决方案：**
检查 `.csproj` 文件中的 `ProjectReference` 路径是否正确

### 问题3：命名空间不一致

**现象：** 编译错误，提示命名空间不存在

**解决方案：**
使用搜索命令检查是否有遗漏的 `Kstopa` 引用

### 问题4：文件名与命名空间不匹配

**现象：** 编译警告或错误

**解决方案：**
确保物理文件名与命名空间保持一致

### 问题5：Shell32 COM 引用导致构建失败（MSB4803）

**现象：**
```
error MSB4803: .NET Core 版本的 MSBuild 不支持"ResolveComReference"。
```

**原因：**
`.NET Core` / `.NET 6+` 版本的 MSBuild 不支持 COM 引用（如 `Shell32`）。原项目使用了 `Shell32.Shell()` 来实现"显示桌面"功能。

**解决方案：**
1. **修改代码**：在 `Wms.Controls\ViewModels\HomeViewModel.cs` 中，使用 P/Invoke 调用 Windows API 替代 Shell32：
   ```csharp
   // 旧代码（使用 Shell32 COM）
   var shell = new Shell32.Shell();
   shell.MinimizeAll();
   
   // 新代码（使用 P/Invoke）
   [DllImport("user32.dll", SetLastError = true)]
   private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
   
   [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
   private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
   
   private void ShowDesktop()
   {
       IntPtr hWnd = FindWindow("Shell_TrayWnd", null);
       if (hWnd != IntPtr.Zero)
       {
           SendMessage(hWnd, 0x0112, (IntPtr)0xF140, IntPtr.Zero);
       }
   }
   ```

2. **移除 COM 引用**：从 `Wms.Controls.csproj` 中删除以下内容：
   ```xml
   <COMReference Include="Shell32">
     <WrapperTool>tlbimp</WrapperTool>
     <VersionMinor>0</VersionMinor>
     <VersionMajor>1</VersionMajor>
     <Guid>50a7e9b0-70ef-11d1-b75a-00a0c90564fe</Guid>
     <Lcid>0</Lcid>
     <Isolated>false</Isolated>
     <EmbedInteropTypes>true</EmbedInteropTypes>
   </COMReference>
   ```

---

## 验证清单

- [x] 所有 `.cs` 文件中的命名空间已更新
- [x] 所有 `.xaml` 文件中的 `x:Class` 和 xmlns 已更新
- [x] 所有 `.csproj` 文件中的项目引用路径已更新
- [x] `.sln` 文件中的项目名称和路径已更新
- [x] 物理文件夹名称已更新
- [x] 项目文件名已更新
- [x] 解决方案文件名已更新
- [x] 解决方案能正常构建
- [ ] 应用程序能正常运行

---

## 补充说明

1. **根目录名称**：项目根目录 `Kstopa.Lx.WMS` 未重命名，如需完全统一可手动重命名为 `Wms`
2. **MesTestTool**：该项目未包含 `Kstopa` 引用，无需修改
3. **ReadMe.md**：已手动更新标题从 `Kstopa.Lx.WMS仓库管理系统` 改为 `Wms 仓库管理系统`
