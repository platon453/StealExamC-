# Перед тем как верстать окна и тд, нужно расписать стили в app.xaml
- `app.xaml`
```c#
<Application.Resources>

    <Style TargetType="Window" x:Key="Windows">
        <Setter Property="Icon" Value="/Res/Icon.ico"/>
    </Style>
    
    <!-- Текст -->
    <Style TargetType="TextBlock">
        <Setter Property="FontFamily" Value="Times New Roman"/>
        <Setter Property="FontSize" Value="20"/>
    </Style>

    <Style TargetType="TextBox">
        <Setter Property="FontFamily" Value="Times New Roman"/>
        <Setter Property="FontSize" Value="20"/>
    </Style>

    <Style TargetType="PasswordBox">
        <Setter Property="FontFamily" Value="Times New Roman"/>
        <Setter Property="FontSize" Value="20"/>
    </Style>

    <Style TargetType="ComboBox">
        <Setter Property="FontFamily" Value="Times New Roman"/>
        <Setter Property="FontSize" Value="20"/>
    </Style>

    <!-- Кнопки -->
    <Style TargetType="Button">
        <Setter Property="FontFamily" Value="Times New Roman"/>
        <Setter Property="FontSize" Value="20"/>
        <Setter Property="Background" Value="#00fa9a"/>
        <Setter Property="BorderBrush" Value="#00a879"/>
        <Setter Property="BorderThickness" Value="2"/>
    </Style>

</Application.Resources>
```
# Описания тегов
## **Стиль для Окна (Window)**
- `<Application.Resources>` — Это корневой элемент для определения ресурсов на уровне всего приложения. Ресурсы, определённые здесь, доступны во всех окнах (Windows) и страницах (Pages) вашего проекта WPF.
- **`<Style>`** — Это тег для создания стиля, который позволяет задавать набор значений свойств (шрифт, цвет, размер и т.д.) для элемента управления. Этот стиль можно переиспользовать.
- **`TargetType="Window"`** — Указывает, к какому типу элементов управления применяется этот стиль. Здесь — ко всем окнам (`Window`).
- **`x:Key="Windows"`** — Это **ключ** (имя) стиля. Он нужен, чтобы явно применять стиль к элементу.
- **`<Setter Property="Icon" Value="/Res/Icon.ico"/>`** — Это "сеттер", он устанавливает конкретное свойство элемента.
	-  `Property="Icon"` — Указываем, какое свойство мы меняем. Здесь это свойство иконки окна.
	- `Value="/Res/Icon.ico"` — Задаём значение свойства. Это путь к файлу иконки. Слэш `/` в начале означает, что путь отсчитывается от корня проекта (обычно папка `Res` находится в проекте, и файл `Icon.ico` лежит внутри неё).

## **Стили для текстовых элементов**
- **`TargetType="TextBlock"`** — Стиль применяется ко всем элементам типа `TextBlock` (это элемент для вывода простого текста) во всём приложении.
- **Отсутствие `x:Key`** — Именно из-за этого стиль применяется **автоматически ко всем** элементам `TextBlock` в приложении. Это называется **неявным стилем**. Вам не нужно прописывать `Style="..."` для каждого `TextBlock`.
- **Сеттеры**:
	- `FontFamily` — **Семейство шрифтов**. "Times New Roman".
	- `FontSize` — **Размер шрифта**. 20 единиц (по умолчанию в WPF это пункты).
- **Аналогично работают следующие три стиля:**
	- 1. **`<Style TargetType="TextBox">`** — Автоматически применяется ко всем полям ввода текста (`TextBox`).
	- 2. **`<Style TargetType="PasswordBox">`** — Автоматически применяется ко всем полям ввода пароля (`PasswordBox`).
	- 3.  **`<Style TargetType="ComboBox">`** — Автоматически применяется ко всем выпадающим спискам (`ComboBox`).
	- *Все они задают шрифт Times New Roman размером 20*.

## **Стиль для кнопок (Button)**
- **`TargetType="Button"`** — Неявный стиль для всех кнопок (`Button`).
- - **`Background`** — Цвет фона элемента. `#00fa9a` — это HEX-код цвета (средний весенне-зелёный).
- **`BorderBrush`** — Цвет границы (рамки) элемента. `#00a879` — тёмно-зелёный.
- **`BorderThickness`** — Толщина границы. `"2"` означает 2 единицы (пикселя) со всех сторон. Можно задавать асимметрично: `"2,1,2,1"` (левый, верхний, правый, нижний).

# **Итог и что важно запомнить:**
1. **Ресурсы (`Application.Resources`)** — Это как общая библиотека или палитра для всего приложения. Вы можете хранить там стили, цвета, шаблоны и потом на них ссылаться.
2. **Стиль (`<Style>`)** — Набор правил оформления для элемента.
3. **`TargetType`** — Говорит стилю, для кого эти правила.
4. **`x:Key`** — Даёт имя ресурсу. Чтобы его использовать, нужно явно сослаться по имени (например, `Style="{StaticResource Windows}"`).
5. **Неявный стиль** — Если `x:Key` не указан, а только `TargetType`, стиль применяется автоматически ко ВСЕМ элементам этого типа в области видимости (в вашем случае — во всём приложении). Это мощный инструмент для единообразия интерфейса.
6.  **`<Setter>`** — Конкретное правило внутри стиля: _какое свойство_ (`Property`) _в какое значение_ (`Value`) установить.
---
# **Перейдем к верстке страницы авторизации**(Теги которые нужно знать)
Переходим в файл `MainWindow.xaml`
```C#
<Window x:Class="ShopShoes123.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:ShopShoes123"
        mc:Ignorable="d" Style="{StaticResource Windows}"
        Title="Авторизация" Height="450" Width="800">
    <Grid>

        <Border VerticalAlignment="Center" HorizontalAlignment="Center">
            <StackPanel Margin="30">

                <TextBlock Text="Авторизация"
                           Margin="40 10"/>
                <TextBox Name="LoginEnter"
                         Margin="20 10"/>
                <PasswordBox
                    Name="PaswwordEnter"
                    Margin="20 10"/>
                <Button Name="LoginInButton"
                        Content="Войти"
                        Margin="40 10"
                        Click="LogInButton_Click"/>
                <TextBlock HorizontalAlignment="Center"
                           Text="Войти как гость"
                           FontSize="13"
                           Foreground="Blue"
                           MouseDown="TextBlock_MouseDown"/>

            </StackPanel>
        </Border>
    </Grid>
</Window>
```
## **ВАЖНЫЕ МОМЕНТЫ**

```c#
mc:Ignorable="d" Style="{StaticResource Windows}"
```
- **ПРИМЕНЕНИЕ СТИЛЯ!** Вот где используется тот самый стиль `Windows` с иконкой, который вы определили в `Application.Resources`. `{StaticResource ...}` — это привязка к ресурсу.
```c#
<Border VerticalAlignment="Center" HorizontalAlignment="Center">
```
- **`<Border>`** — декоративный контейнер
	- Обычно используется для рамок, фона, скругления углов
	- **`VerticalAlignment="Center"`** — выравнивание по вертикали: "центр"
	- **`HorizontalAlignment="Center"`** — выравнивание по горизонтали: "центр"
	- Вместе они центрируют Border по середине окна
```c#
<StackPanel Margin="30">
```
- **`<StackPanel>`** — контейнер-"стек"
	- **ВАЖНАЯ КОНЦЕПЦИЯ:** Располагает дочерние элементы в стопку:
- **`Margin="30"`** — внешние отступы: `30` **пикселей со всех сторон**
```c#
<TextBlock Text="Авторизация" Margin="40 10"/>
```
- **`<TextBlock>`** — элемент для отображения текста (только чтение)
- **`Text="Авторизация"`** — содержимое текста
- **`Margin="40 10"`** — отступы: **40** слева/справа, **10** сверху/снизу
```c#
<TextBox Name="LoginEnter" Margin="20 10"/>
```
- `<TextBox>` — поле для ввода текста (однострочное)
- **`Name="LoginEnter"`** — **ВАЖНО!** Это имя переменной в C# коде. В файле `MainWindow.xaml.cs` вы можете обращаться к этому элементу как `LoginEnter.Text`
- Аналогично `PasswordBox` для пароля
```C#
<Button Name="LoginInButton" Content="Войти" Margin="40 10" Click="LogInButton_Click"/>
```
- **`<Button>`** — кнопка
- **`Content="Войти"`** — текст на кнопке (может быть не только текст, но и изображение, другой элемент)
- **`Click="LogInButton_Click"`** — **ОБРАБОТЧИК СОБЫТИЯ!** Указывает на метод в C# классе, который выполнится при клике. Должен быть метод
```
<TextBlock Text="Войти как гость"
           Margin="20 10"
           FontSize="13"
           TextAlignment="Center"
           MouseDown="TextBlock_MouseDown"
           Foreground="Blue"/>
```
- Базовый `<TextBlock>` 
- `Text`, `Margin`, `FontSize` уже знаем
- `TextAlignment="Center"` - выравниваем по центру
- `Foreground="Blue"` - цвет текста переднего плана(синий)
- **`MouseDown="TextBlock_MouseDown"`** — обработчик нажатия мыши на текст (как ссылка "войти как гость")

### На этом верстка авторизации закончена 
## **Моменты которые нужно знать!!**
1. **Иерархия элементов** (вложенность):
```
Window → Grid → Border → StackPanel → [элементы]
```
2. **Имена элементов (`Name`) ≠ Ключи ресурсов (`x:Key`)**:
- `Name` — для обращения из C# кода
- `x:Key` — для обращения из XAML к ресурсу
3. **Margin vs Padding**:
- `Margin` — отступ **внешний** (от элемента до соседей/границ)
- `Padding` — отступ **внутренний** (от границы элемента до его содержимого)
2. **События (`Click`, `MouseDown`) всегда ведут на методы в C#**
---
# **Теперь пропишем бек для авторизации**
Переходим в файл `MainWindow.xaml.cs` и нажимаем `Ctrl r` + `Ctrl g` чтобы почистить `usning`
# 1. MainWindow.xaml.cs (основной файл)

```csharp
using DemExamRepit.Helpers;      // Ваши вспомогательные классы
using DemExamRepit.Static;        // Статические классы (сессии)
using System.Linq;                // LINQ для работы с БД
using System.Windows;            // Базовые классы WPF
using System.Windows.Input;      // Обработка ввода (не используется в этом коде)
```
- Импорты (using):
- **Важно: LINQ (`System.Linq`) позволяет писать запросы к коллекциям и БД в стиле SQL.**
```csharp
public partial class MainWindow : Window
```
- `partial` означает, что класс разделён на две части: XAML-часть (`MainWindow.xaml`) и C#-часть (`MainWindow.xaml.cs`). При компиляции они объединяются.
```csharp
private PROBNIKEntities _db = new PROBNIKEntities();
private MessageHelper _mh = new MessageHelper();
```
- **`_db`** — экземпляр Entity Framework контекста базы данных. Автоматически создан из вашей БД. Через него вы обращаетесь к таблицам
- **`_mh`** — ваш вспомогательный класс для показа сообщений. Используется для инкапсуляции логики MessageBox.
```csharp
public MainWindow()
{
    InitializeComponent(); // Автоматически сгенерированный метод, загружает XAML
}
```
- **Конструктор**: 
```csharp
private void LogInButton_Click(object sender, RoutedEventArgs e)
{
    // 1. Получаем данные из полей ввода
    string login = LoginEnter.Text;
    string password = PaswwordEnter.Password;

    // 2. Запрос к БД через LINQ
    var user = _db.Users.Where(u => u.Login == login && u.Password == password).FirstOrDefault();

    // 3. Проверка результата
    if (user == null)
    {
        _mh.ShowError("Введен неправильный логин или пароль!");
        return; // Выход из метода
    }
    else
    {
        // 4. Сохраняем пользователя в сессии
        CurrentSession.CurrentUser = user;
        
        // 5. Открываем новое окно и закрываем текущее
        new ProductWindow(user).Show();
        Close();
    }
}
```
- **Метод авторизации:**
```csharp
var user = _db.Users
    .Where(u => u.Login == login && u.Password == password)
    .FirstOrDefault();
```
- **`_db.Users`** — обращение к таблице Users в БД
- **`.Where(...)`** — фильтрация (аналог WHERE в SQL)
- **`u => u.Login == login`** — лямбда-выражение: для каждого пользователя `u` проверяем равенство логина
- **`FirstOrDefault()`** — берёт первого подходящего пользователя или возвращает `null`, если таких нет
```csharp
private void TextBlock_MouseDown(object sender, RoutedEventArgs e)
{
    new ProductWindow().Show(); // Открываем окно без пользователя
    Close(); // Закрываем окно авторизации
}
```
- Вызывается при клике на TextBlock "Войти как гость"
- `new ProductWindow().Show()` — создает и показывает новое окно товаров
- `Close()` — закрывает текущее окно авторизации
---
# 2. Helpers/MessageHelper.cs

```csharp
public class MessageHelper
{
    public void ShowInfo(string message)
    {
        MessageBox.Show(message, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
    }
    // ... аналогично ShowError и ShowWarning
}
```
- **Преимущества:**
	- Убирает дублирование кода
	- Единый стиль сообщений во всём приложении
	- Легко изменить оформление всех сообщений в одном месте
- **Параметры MessageBox:**
	- `message` — текст сообщения
	- `"Информация"` — заголовок окна
	- `MessageBoxButton.OK` — какие кнопки показывать (OK, YesNo и т.д.)
	- `MessageBoxImage.Information` — иконка (Information, Error, Warning, Question)
---
# 3. Static/CurrentSession.cs

```csharp
public static class CurrentSession
{
    public static Users CurrentUser { get; set; }
}
```
- **Зачем это нужно:**
	- Доступ к текущему пользователю из любой части приложения
	- Не нужно передавать пользователя через параметры всех методов
	- Хранит состояние сессии (кто залогинился)
- **Осторожно!** В реальных приложениях нужно:
	- - Добавить проверку на `null`
	- - Реализовать логout (обнуление `CurrentUser`)
	- Рассмотреть потокобезопасность (хотя в WPF обычно один UI-поток)
---
# 4. ProductWindow.xaml.cs

```csharp
public partial class ProductWindow : Window
{
    public ProductWindow() // Для гостя
    {
        InitializeComponent();
    }

    public ProductWindow(Users user) // Для авторизованного пользователя
    {
        InitializeComponent();
        // Здесь можно инициализировать окно в зависимости от пользователя
        // Например: Title = $"Добро пожаловать, {user.Name}!";
    }
}
```
- Создается экземпляр `ProductWindow`, передается пользователь
- Вызывается `.Show()` — окно отображается
- Вызывается `.Close()` — закрывается окно авторизации
---
