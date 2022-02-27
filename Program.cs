using Google;
using System;
using System.Linq;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (helloappdbContext db = new helloappdbContext())
            {
                User user1 = new User { Name = "Tom", Age = 33 };
                User user2 = new User { Name = "Alice", Age = 26 };
                // Добавление
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
            }
            // получение
            using (helloappdbContext db = new helloappdbContext())
            {
                // получаем объекты из БД и выводим на консоль
                var users = db.Users.ToList();
                Console.WriteLine("Данные после добавления:");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
            // Редактирование
            using (helloappdbContext db = new helloappdbContext())
            {
                // получаем первый объект
                User user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    user.Name = "Bob";
                    user.Age = 44;
                    //обновляем объект
                    db.Users.Update(user);
                    db.SaveChanges();
                }
                // выводим данные после обновления
                Console.WriteLine("\nДанные после редактирования:");
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
            // Удаление
            using (helloappdbContext db = new helloappdbContext())
            {
                // получаем первый объект
                User user = db.Users.FirstOrDefault();
                if (user != null)
                {
                    //удаляем объект
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
                // выводим данные после обновления
                Console.WriteLine("\nДанные после удаления:");
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
            Console.Read();
        }
    }
}

//            using (helloappdbContext db = new helloappdbContext())
//            {
//                // получаем объекты из БД и выводим на консоль
//                var users = db.Users.ToList();
//                Console.WriteLine("Список объектов:");
//                foreach (User u in users)
//                {
//                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
//                }
//            }
//            Console.ReadKey();
//        }
//    }
//}