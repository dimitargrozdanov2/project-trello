# Project - Trello

Първоначално идеята на проекта ни беше да създадем командите без **Engine** само с методи, 
но в последствие опитахме и ни хареса да правим командите чрез **Engine**. 

Започнахме като си дефинирахме класовете **Team**, **Person** и **Teams**.  Важно е да се отбележи, че Person не е просто Member - той може да не е член на нито един Team.
После осъзнахме ,че може в **Engine**  да използваме 2 **dictionaries** – един за **Teams** и един за **People**. 
Така премахнахме класа **Member**. Също така **Dictionaries** работят по стринг и връщат резултат т.е ние използвахме ключа, 
за да ни върне value, което беше доста полезно. Дефинирахме абстрактен **WorkItem** клас,
a за ID-to използвахме статичен клас **IDGenerator**.  Използвайки наследяването наследихме на **Bug, Feedback , Story от WorkItem**. 
В конструктора на класовете добавихме адд метод на **ActivityHistory** , за да записва създаването при инстанцирането на даден клас.

Енкапсуралихме детайлите на всеки клас и сложихме необходимите валидации. 
Няколко пъти използвахме полиморфирма за  **override**. Например **Execute** в Командните класове. 

Създадохме интерфейси, който после обхождахме. Например при метода Execute обхождаме **IList <string> parameters**.
В класа Team имаме **IList <Person> members**. По този начин не създаваме отделен клас за **Members**. 
Всеки един клас сам по себе си има и интерфейс.

При принтирането използвахме **StringBuilder**.
Също така използвахме различни енумерации при различните класове  - при **Bug** използвахме различни степени на Severity и Priority.
Ползвахме различни енумерации и при  **Story и Feedback**.

За create bug/story/feedback първоначално използвахме метод в класа Team, 
който да вземе името на отбора, в който ще се създаде определния обект. След това в борд намираме името  като търсим в листа по индекс.
След това използваме този индекс в **Engine** , за да върне правилния резултат. 
Вместо по име имахме идея да търси по ID, тъй като и 3-те имат ID, но за да е user friendly се отказахме от тази идея. 

Преминахме през  перипетии с гитлаб,в който се получава **Merge conflicts**.
Не можех да revert към по-стара версия, тъй като тази функционалност не беше доступна. 
Трябваше да ги оправяме на ръка. Научихме се да пазим backup на всеки наш проект локално.

Филтрацията и сортировката, използвахме **LinQ**.  Използвахме статичен **Extension** клас , в който **TryParse** всички enum.
Ако не се получи връща false на булева променлива success.

Изпозваме 1 статичен и 2 extention класове, за да обединим съобщенията и грешките в едно. 
Имаме един клас **ErrorMessages, ReplaceBrackets extension** , който заменя скобите и един валидиращ extention клас, в който проверяваме дали е 0 , или е в рамките зададени от условието. При неверен резултат връща exception.

За workflow на **Engine** работи по следния начин: 
  
*	Подава се команда на конзолата
*	Енджина я парсва
*	Проверява дали е валидна
*	Ако е валидна връща резултат
*	Резултата се принтира на конзолата
*	Връщаме се в енджина – ако няма команда еxit чака следващата команда от конзолата.

