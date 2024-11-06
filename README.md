Механика кликера и автосбора

Задача содержит перечень требований и описание функционала. Требуется
разработать новый проект, который состоит из нескольких элементов:

  • Кнопка, нажатие на которую дает софт валюту
  • Система «автосбор», дающая регулярный доход софт валюты (подробнее в
пункте «автосбор)
    o Сделать связь через модификатор от «автосбора» к нажатию на
«кликер» (подробнее в пункте «Автосбор»)

Бонусом будет объяснение того, почему был выбран именно такой подход к
реализации.

Краткое резюме задачи
Создать систему получения софт валюты за тап. Создать «автосборщик»,
который каждые N секунд начисляет пассивно X софт валюты.
Опционально – сделать связь между кликером и автосбором, чтобы 10% от
начисляемых автосбором средств прибавлялось к доходу, который игрок получает
за каждый тап (пример: если автосбор начисляет 100 софт валюты, то каждый тап должен
давать дополнительно 10% софт валюты от 100)

Кликер (подробное описание)
На главном экране находится кликер-объект, при нажатии на зону клика которого
происходит списание X единиц энергии и начисление Y единиц софт валюты.
При сборе софт валюты возникает и “улетает” анимированное число софт валюты в
количестве Y

Софт валюта за тап
Количество получаемой софт валюты задается геймдизайнерами в scriptable object
клик механики с помощью следующих переменных:
  ● Базовое число софт валюты получаемое за тап
  ● Модификатор тапа (по умолчанию цифра, 1 к которой могут быть прибавлены
другие значения от других переменных)
  ● Модификатор иной переменной (состоит из двух множителей)
    ○ Сумма доходов от заданного в настройках scriptable object значения в T
времени
    ○ Делитель, который задается гейм дизайнером в том же SO
    
Автосбор
Каждые N секунд игроку начисляется X софт валюты.

Дополнительная задача (опционально)
10% от получаемой софт валюты X прибавляется к доходу c каждого тапа
совершаемого игроком.
