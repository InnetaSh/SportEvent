//Задание: Разработка системы управления событиями в спортивном приложенииОписание задачи:Вы должны разработать систему управления событиями для спортивного приложения,
//которое позволяет пользователям подписываться на различные виды спортивных событий (например, футбольные матчи, баскетбольные игры, теннисные турниры и т.д.).
//Когда происходит определённое спортивное событие, система должна уведомлять всех подписанных пользователей.
//Требования:
//Создание классов событий:Создайте базовый класс SportEvent,
//который будет содержать общие свойства и методы для всех спортивных событий.
//Создайте производные классы, такие как FootballMatch, BasketballGame, TennisTournament,которые будут наследовать SportEvent.

//Создание делегатов и событий:Создайте делегат EventHandler для обработки уведомлений о спортивных событиях.
//В классе SportEvent определите событие EventOccurred, которое будет срабатывать при наступлении события.
//
//Подписка на события:Создайте класс User,
//который будет представлять пользователя приложения. Этот класс должен содержать метод Notify, который будет вызываться при наступлении события.
//Реализуйте возможность подписки пользователей на конкретные спортивные события. Для этого создайте метод Subscribe,
//который добавляет метод Notify пользователя к событию EventOccurred.
//Уведомление пользователей:Реализуйте метод TriggerEvent в каждом классе событий
//(например, FootballMatch, BasketballGame), который будет вызывать событие EventOccurred.


using System.Xml.Linq;




FootballMatch footballMatch = new FootballMatch("EVRO 2024", new DateTime(2024, 6, 1, 20, 0, 0), "Team A", "Team B");
BasketballGame basketballGame = new BasketballGame("NBA  Game 1", new DateTime(2024, 6, 15, 21, 0, 0), "Team 1", "Team 2");
TennisTournament tennisTournament = new TennisTournament("Wimbledon", new DateTime(2024, 7, 1), "Player 1", "Player 2");

User user1 = new User("Danya");
User user2 = new User("Kostya");


footballMatch.Subscribe(user1);
footballMatch.Subscribe(user2);

basketballGame.Subscribe(user1);
tennisTournament.Subscribe(user2);


footballMatch.StartEvent();
basketballGame.StartEvent();
tennisTournament.StartEvent();

class SportEvent
{
    public string EventName;
    public DateTime EventDate;
    SportEventHandler? taken;

    public SportEvent(string eventName, DateTime dateTime)
    {
        EventName = eventName;
        EventDate = dateTime;
    }

    public delegate void SportEventHandler(SportEvent se);

    public event SportEventHandler Event;
    public virtual void OnEvent()
    {

        Event?.Invoke(this);
    }
    public virtual void EventInfo()
    {
        Console.WriteLine($"{EventName} произойдет {EventDate}");
    }
    public void Subscribe(User user)
    {
        Event += user.Notify;
    }
    public virtual void StartEvent()
    {
        //EventInfo();
        OnEvent();
    }
}

class FootballMatch :SportEvent
{
    public string Team1;
    public string Team2;
    public FootballMatch(string eventName, DateTime date, string team1, string team2) : base(eventName,date)
    {
        Team1 = team1;
        Team2 = team2;
    }
    public override void EventInfo()
    {
        base.EventInfo();
        Console.WriteLine($"матч состоится между командами {Team1} и {Team2}");
        
    }
}

class BasketballGame : SportEvent
{
    public string Team1;
    public string Team2;
    public BasketballGame(string eventName, DateTime date, string team1, string team2) : base(eventName, date)
    {
        Team1 = team1;
        Team2 = team2;
    }
    public override void EventInfo()
    {
        base.EventInfo();
        Console.WriteLine($"игра состоится между командами {Team1} и {Team2}");
       
    }
}


class TennisTournament : SportEvent
{
    public string Player1;
    public string Player2;
    public TennisTournament(string eventName, DateTime date, string player1, string player2) : base(eventName, date)
    {
        Player1 = player1;
        Player2 = player2;
    }
    public override void EventInfo()
    {
        base.EventInfo();
        Console.WriteLine($"игра состоится между спортсменами {Player1} и {Player2}");
       
    }
}



class User
{
    public string Name;
    public User(string name)
    {
        Name = name;
    }

    public void Notify(SportEvent sportEvent)
    {
        Console.WriteLine($"{Name} получил уведомление: ");
        sportEvent.EventInfo();
        Console.WriteLine("------------------------------------------------------------");
    }
    
}



















//Разработайте простую систему управления событиями в спортивной команде, используя делегаты в C#. В этой системе должно быть несколько типов событий, таких как тренировки, матчи и собрания команды.
//Каждый участник команды должен получать уведомления о предстоящих мероприятиях.

//Требования:
//Создайте делегат EventNotification для уведомлений о событиях.

//Создайте класс TeamEvent, который будет представлять событие. Этот класс должен содержать следующие свойства:

//string EventName
//DateTime EventDate
//EventNotification Notify


//Реализуйте метод в классе TeamEvent, который будет вызывать делегат для уведомления участников

//Создайте класс TeamMember, который будет представлять участника команды. Этот класс должен содержать следующие свойства
//string Name

//В классе TeamMember создайте метод ReceiveNotification для получения уведомлений
//Напишите программу, которая будет создавать несколько событий и участников команды, регистрировать участников на события и уведомлять их о предстоящих мероприятиях

//TeamEvent eventT = new TeamEvent("тренировка");
//var tm1 = new TeamMember("Vasya");
//var tm2 = new TeamMember("Fedya");


//eventT.RegistrHandler(tm1.ReceiveNotification);
//eventT.RegistrHandler(tm2.ReceiveNotification);

//eventT.Notifications(new DateTime(2024, 6, 25));
//eventT.Notifications(new DateTime(2024, 6, 29));

//Console.WriteLine("----------------------------------------------------------------");
//TeamEvent eventM= new TeamEvent("матч");

//eventM.RegistrHandler(tm1.ReceiveNotification);
//eventM.RegistrHandler(tm2.ReceiveNotification);

//eventM.Notifications(new DateTime(2024, 7, 01));

//Console.WriteLine("----------------------------------------------------------------");
//TeamEvent eventS = new TeamEvent("собрание");

//eventS.RegistrHandler(tm1.ReceiveNotification);
//eventS.RegistrHandler(tm2.ReceiveNotification);

//eventS.Notifications1(new DateTime(2024, 6, 30));

//public delegate void EventNotification(string message);

//internal class TeamEvent
//{
//    string EventName;
//    DateTime EventDate;
//    EventNotification? Notify;

//    public TeamEvent(string eventName)
//    {
//        EventName = eventName;
//    }
//    public void RegistrHandler(EventNotification del)
//    {
//        Notify += del;
//    }

//    public void Notifications(DateTime eventDate)
//    {
//        Notify?.Invoke($"{eventDate} запланирован(а) {EventName}");
//    }
//    public void Notifications1(DateTime eventDate)
//    {
//        Notify?.Invoke($"{eventDate} запланировано {EventName}");
//    }
//}

//class TeamMember
//{
//    string Name;
//    public TeamMember(string name)
//    {
//        this.Name = name;
//    }
//    public void ReceiveNotification(string message)
//    {
//        Console.WriteLine($"Участник {Name} получил уведомление: {message}");
//    }
//}

