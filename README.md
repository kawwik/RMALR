﻿# RMALR
Автоматический генератор парсеров.
Позволяет задать собственную грамматику и сгенерировать по ней лексер,
разбивающий входные данные на токены и парсер, генерирующий по потоку токенов
синтаксическое дерево.

Поддерживает LL-1 разбор, наследуемые и синтезируемые атрибуты,
а также встроенные действия на C#.

## Примеры
В репозитории содержатся 2 примера использования:
1) Калькулятор. \
   Поддерживает стандартные арифметические операции. 
   Также содержит оператор choose, вычисляющий количество сочетаний.
2) Парсер логических выражений на python.
   Стандартные логические выражения в стиле python.
   В качестве результата генерирует код для GraphViz с деревом разбора.