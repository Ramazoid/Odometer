# Odometer
Тестовое техническое задание
Ассеты к данному заданию на ваш выбор. Музыкальное сопровождение к заданию на
ваш выбор. Смена состояний элементов UI должна содержать анимацию.
API для получения одометра к данному тестовому заданию:
Endpoint - ws://185.246.65.199:9090/ws
Формат сообщения JSON
Ключ передачи метода «operation»
Каждые 10 секунд передается значение одометра - {«operation»: «odometer_val», «value»:
<FLOAT> }
Что бы запросить одометр необходимо послать запрос на сервер - {«operation»:
«getCurrentOdometer»}, в ответ придет - {«operation»: «currentOdometer», «odometer»:
<FLOAT>}
Получения случайного значения правда/лож - {«operation»: «getRandomStatus»}, в ответ
приходит либо status = true {«operation»: «randomStatus», «status»: true, «odometer»:
<FLOAT>}, либо status = false {«operation»: «randomStatus», «status»: false}
ПОТОКОВОЕ ВЕЩАНИЕ ведется из программного обеспечения VLC. Трансляция
осуществляется через протокол RTSP
Приложение содержит:
1. Кнопка «МЕНЮ»
2. Музыкальное и звуковое сопровождение
3. Checkbox
4. Одометр
5. Кнопка «Старт»
6. Лампа (зеленый/красный) соединение с сервером установлено или отсутствует.
Настройки конфигурации:
Адрес сервера должен храниться в файле config.txt
Порт сервера должен храниться в файле config.txt
Пример содержимого файла config.txt:
Адрес сервера: 192.168.1.1
Порт: 80
Кнопка «МЕНЮ» содержит настройки:
1. Включить/выключить звуки
2. Включить/выключить музыку
3. Адрес сервера
4. Адрес порта
5. Адрес видео потока
6. Ползунок регулировки громкости фоновой музыки и звуков
Алгоритм работы:
1. После запуска приложения начинает играть музыка и происходит автоматическое
подключение к серверу, после чего лампа состояния подключения принимает необходимый
цвет. При обрыве соединения должна выполняться попытка переподключения к серверу в
автоматическом режиме с выводом сообщения пользователю и сменой состояния лампы.
2. Одометр стартовые значения «0». Изменяется динамически согласно полученному
значению с сервера с плавной анимацией смены числа.
3. Кнопка «Старт» запускает видео в рамке ниже одометра. Если видео содержит звук, то
видео идет со звуком вместо фоновой музыки.
Удачи в выполнении задания!
