# DataSyncApi
## Контекст
Предположим, что у нас есть сущность [Источника данных](DataSyncApi/Models/DataSource.cs), которая подразумевает набор параметров для подключения к какой-то БД, для простоты пусть это будет postgres
У нас есть [Набор данных](DataSyncApi/Models/Dataset.cs), который представляет из себя таблицу в БД в Источнике. У набора есть список полей с инфой о названии колонки и типе данных.

Нам необходимо перегружать данные из этого стороннего источника в нашу локальную БД (опять же, пусть это будет постгрес). Процесс может занимать несколько минут. Процесс может завершиться ошибкой или успехом.

## Суть задачи
+ реализовать API для проверки статусов перегрузки данных по всем имеющимся наборам.
+ реализовать сущности Источника, Набора а так же необходимые для API вспомогательные сущности.

## НЕ нужно реализовывать
- редактирование сущностей
- саму перегрузку данных 
- визуальную часть.
