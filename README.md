CS3

1. Посмотрите внимательно на приложение, при помощи которого мы тестировали возможность отправлять электронные письма и начали изучать WPF. Посмотрите внимательно на код. В коде есть несколько моментов, которые простительны для теста, но непростительны для серьёзного приложения.
a. Первый момент: жестко заданные переменные в коде. Например, new SmtpClient("smtp.yandex.ru", 25), в этой строке две жестко заданные переменные: "smtp.yandex.ru" – smtp-сервер и 25 – порт для этого сервера. В коде много и других жестко заданных переменных: адреса почтовых ящиков, тексты писем, тексты ошибок и др.
Задание: добавить в проект WpfTestMailSender public static class, без конструктора и методов. Определить в этом классе статические переменные и задать им значения. В коде использовать эти переменные вместо жестко заданных.
b. Второй момент, который также простителен для тестовой программы и нежелателен для более или менее серьезного приложения. Код, который описывает форму, и код, который занимается непосредственно рассылкой, содержится в одном классе.
Задание: добавить к проекту WpfTestMailSender public class, назвать его, например, EmailSendServiceClass с конструктором. Создать в этом классе методы (или метод), которые будут заниматься рассылкой писем. Класс надо создать таким образом, чтобы его можно было легко перенести в другой проект.
c. В коде присутствует MessageBox с выводом ошибки в случае невозможности отправить письма. В принципе, MessabeBox — не криминал и даже в серьезных проектах они присутствуют, но всё-таки окно со своим стилем выглядит лучше.
Задание: по аналогии с формой, которая выводит сообщение «Работа завершена», создайте ещё одну для вывода текста ошибки. Цвет текста ошибки пусть будет красным. Также добавьте кнопку «ОК», которая будет закрывать форму.
2. Теперь задание на укрепление знаний технологии WPF.
a. Добавить на главное окно тестового проекта WpfTestMailSender, в любое место формы два контрола TextBox, одно для названия письма, второе для самого текста письма. И сделайте так, чтобы название письма и текст письма брались из этих контролов.
b. Скачать библиотеку стилей или тем (theme) с сайта http://wpfthemes.codeplex. Как описано в главе Изменение стиля приложения WPF, выберите любой стиль по своему усмотрению и замените стиль, сделайте так же, как было описано на уроке.
c. Поиграйте с контролами тестового приложения WpfTestMailSender, поменяйте их свойства, поразмещайте в разных местах окна. Поменяйте основную панель Grid на другие панели, которые мы рассматривали на уроке.
3. Заменить название основного окна и класса приложения MailSender, MainWindow на WpfMailSender, сделать по аналогии с тем, как мы меняли название главного окна у тестового приложения WpfTestMailSender на уроке.