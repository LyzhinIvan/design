Выполнил: Лыжин Иван

# Блок "Проектирование"

Сделайте fork этого репозитория.
Делайте commit и push после окончания выполнения каждого задания.

## Задача 1. Fluent API

Раскомментируйте код в проекте FluentApi. Создайте недостающие классы, чтобы проект заработал.
Say и Jump должны выводить соответствующие сообщения на экран.
UnitlKeyPressed — выполнять действия, пока пользователь не нажмет какую-нибудь клавишу в консоли.
Delay — к паузе между последовательными действиями.

## Задача 2. using

Раскомментируйте код в проекте PerfLogger. 
Создайте недостающий класс, чтобы проект заработал и начал засекать время выполнения операции внутри using-а.

Проинтерпретируйте полученные результаты замеров.

## Задача 3. DI-сontainer

Откройте проект DIContainer

1. Внедрите Ninject container для создания Program. (см. метод Program.Main)
2. Добавьте команду HelpCommand, печатающую список всех доступных команд (в том числе себя). Для этого придется побороть циклическую зависимость.
3. Сделайте явной зависимость от TextWriter и используйте его, вместо консоли и в командах и в Program.

## Задача 4. Dependency Elimination

Откройте проект DependencyElimination.

Отрефакторите код так, чтобы он распался на модули:

* не связанные даже по интерфейсам
* логичные, универсальные и повторно используемые
* легко тестируемые
