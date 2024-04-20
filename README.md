# ProgTech
# RU description
Лабораторные работы по технологиям программирования.
Работы выполнены на ЯП C#. Для выполнения работы используется [.NET SDK v 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0), VS Code с дополнительными расширениями [.NET Install Tool](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) и [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp).
## Использование программ
Прежде чем использовать программу нам требуется установить [.NET SDK v 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) и [ASP.NET Core](https://learn.microsoft.com/ru-ru/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-8.0). Расскажу как это сделать на Linux в моем случае Ubuntu 20.04.6 LTS.
Добавление репозитория пакетов Microsoft:
```
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```
Установка SDK пакета:
```
sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-8.0
```
Установка среды выполнения ASP.NET:
```
sudo apt-get update && \
  sudo apt-get install -y aspnetcore-runtime-8.0
```
Проверьте установку:
`dotnet --version`
Если после этого выдает версию .NET, то установка прошла успешно в ином случае обращайтесь к источнику и FAQ на сайте [.NET SDK v 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

Перейдем к тому, как выполнять программу. В случае если файл сборки правильный для особенностей вашей системы и версии, то достаточно использовать в консоли команду: `dotnet run <name_of_file>`, в нашем случае `<name_of_file>` - `main.cs` или `Program.cs`.

## Интерпретация заданий лабораторных работ
- [x] [lab1](https://github.com/IKdotShark/ProgTech/wiki/lab1) Реализовать с помощью отдельных классов динамический целочисленный список, односвязный динамический целочисленный список и действия с ним (добавить элемент, вставка элемента по позиции, this, удалить элемент по позиции, очистка списка и его вывод).
- [x] [lab2](https://github.com/IKdotShark/ProgTech/wiki/lab2) Добавить абстрактный родительский класс BaseList с расширением возможностей управления list'ами, подробности описаны в wiki.
- [x] [lab3](https://github.com/IKdotShark/ProgTech/wiki/lab3) Параметрезированные классы, работа с файлами, исключения, делигаты.
- [ ] [lab4](https://github.com/IKdotShark/ProgTech/wiki/lab4) Транспилировать lab2 на C++.
      
--- 

# ENG description
Laboratory work on programming technologies.
The work was performed in C#. To do the work, use [.NET SDK v 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0), VS Code with additional extensions [.NET Install Tool](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) and [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp).
## Using programs
Before using the program, we need to install [.NET SDK v 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) and [ASP.NET Core](https://learn.microsoft.com/ru-ru/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-8.0). I'll tell you how to do this on Linux in my case Ubuntu 20.04.6 LTS.
Adding a Microsoft Package Repository:
```
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```
Installing the SDK package:
```
sudo apt-get update && \
   sudo apt-get install -y dotnet-sdk-8.0
```
Installing the ASP.NET runtime:
```
sudo apt-get update && \
   sudo apt-get install -y aspnetcore-runtime-8.0
```
Check installation:
`dotnet --version`
If after this it displays the .NET version, then the installation was successful, otherwise refer to the source and FAQ on the website [.NET SDK v 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) .

Let's move on to how to execute the program. If the assembly file is correct for the features of your system and version, then it is enough to use the command in the console: `dotnet run <name_of_file>`, in our case `<name_of_file>` - `main.cs` or `Program.cs`.
## Interpretation of laboratory tasks
- [x] [lab1](https://github.com/IKdotShark/ProgTech/wiki/lab1) Implement using separate classes a dynamic integer list, a singly linked dynamic integer list and actions with it (add an element, insert an element by position, this, remove element by position, clear the list and output it).
- [x] [lab2](https://github.com/IKdotShark/ProgTech/wiki/lab2) Add an abstract parent class BaseList with extended list management capabilities, details are described in the wiki.
- [x] [lab3](https://github.com/IKdotShark/ProgTech/wiki/lab3) Parameterized classes, working with files, exceptions, delegates.
- [ ] [lab4](https://github.com/IKdotShark/ProgTech/wiki/lab4) Transpilate lab2 into C++.
