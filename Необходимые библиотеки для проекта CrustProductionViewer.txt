# Необходимые библиотеки для проекта CrustProductionViewer

Для разработки приложения CrustProductionViewer для анализа производства в игре The Crust на WinUI 3 потребуются следующие библиотеки:

## Основные пакеты NuGet

1. **Базовые библиотеки WinUI 3:**
   - `Microsoft.WindowsAppSDK` - основа для WinUI 3 приложений
   - `Microsoft.Windows.SDK.BuildTools` - инструменты сборки для Windows SDK

2. **MVVM и инфраструктура:**
   - `Microsoft.Extensions.DependencyInjection` - для внедрения зависимостей
   - `CommunityToolkit.Mvvm` - для реализации паттерна MVVM

3. **Пользовательский интерфейс:**
   - `CommunityToolkit.WinUI.UI.Controls` - дополнительные UI компоненты
   - `CommunityToolkit.WinUI.UI.Animations` - для анимаций в UI
   - `Microsoft.UI.Xaml.Controls.DataGrid` - для отображения табличных данных

4. **Работа с памятью процесса:**
   - `System.Diagnostics.Process` (встроенная в .NET)
   - `Memory.dll.x64` или альтернатива для работы с памятью процессов
   
   Обратите внимание: для доступа к памяти процесса игры может потребоваться использовать специализированные библиотеки, не все из которых доступны в виде NuGet пакетов. Возможно, потребуется добавить внешнюю библиотеку или создать свою:
   - Альтернативы: `ProcessMemory`, `SharpMemory` или `VAMemory`

5. **Визуализация данных:**
   - `LiveCharts2.WinUI3` - для создания интерактивных графиков и диаграмм
   - или `ScottPlot.WinUI` - также хорошая библиотека для визуализации данных

6. **Утилиты:**
   - `Newtonsoft.Json` - для работы с JSON
   - `Serilog` - для логирования
   - `System.Reactive` - для работы с реактивным программированием

## Команда для установки пакетов

Вы можете установить эти пакеты через NuGet Package Manager в Visual Studio или через Package Manager Console следующими командами:


```powershell
# Основные библиотеки
Install-Package Microsoft.WindowsAppSDK
Install-Package Microsoft.Windows.SDK.BuildTools

# MVVM и DI
Install-Package CommunityToolkit.Mvvm
Install-Package Microsoft.Extensions.DependencyInjection

# UI компоненты
Install-Package CommunityToolkit.WinUI.UI.Controls
Install-Package CommunityToolkit.WinUI.UI.Animations
Install-Package Microsoft.UI.Xaml.Controls.DataGrid

# Визуализация
Install-Package LiveCharts2.WinUI3
# или
# Install-Package ScottPlot.WinUI

# Утилиты
Install-Package Newtonsoft.Json
Install-Package Serilog
Install-Package Serilog.Sinks.File
Install-Package System.Reactive

```

## Особые библиотеки

Для чтения памяти процесса игры, скорее всего, вам придется реализовать собственный сервис, использующий Windows API через P/Invoke. Альтернативно, вы можете использовать одну из библиотек для работы с памятью процесса, которая не находится в NuGet:

1. `Memory.dll` - популярный вариант
2. Реализовать собственный класс с использованием следующих Windows API:
   - OpenProcess
   - ReadProcessMemory
   - VirtualQueryEx
   - и другие

Для этого потребуется добавить P/Invoke определения этих функций в ваш код.
