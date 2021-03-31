CS3

Кудряшов Сергей

2. Есть ли проблемы в следующем коде?
int i = 1;
object obj = i;
++i;
Console.WriteLine(i);
Console.WriteLine(obj);
Console.WriteLine((short)obj);
3. Есть таблица Users. Столбцы в ней — Id, Name. Написать SQL-запрос, который выведет имена пользователей, начинающиеся на 'A' и встречающиеся в таблице более одного раза, и их количество.
4. Каков результат вывода следующего кода?
private enum SomeEnum
{
    First = 4,
    Second,
    Third = 7
}
static void Main(string[] args)
{
    Console.WriteLine((int)SomeEnum.Second);
}
5. *Существует таблица (см. методичку к уроку, раздел ДЗ).
Необходимо сформировать SQL-запрос, выбирающий данные (см. методичку к уроку, раздел ДЗ).