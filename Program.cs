using System;

namespace Programm
{
    class Program
    {

        static void Main(string[] args)
        {
            Person person = new Person();

            while (person.getBalance() > 0)
            {
                // ввод ставки и её проверка
                int bet = 0;
                inputBet(ref bet, person);
                if (!checkBetValue(bet, person)) continue;

                // выбор пользователя, а затем проверка результата
                String choice = "";
                inputChoice(ref choice);
                if (!checkResult(choice, person, bet)) continue;

                if (isBalanceEmpty(person)) break;  // завершение игры при нулевом балансе       
                if (exitFromApp()) break;  // завершение игры (по желанию пользователя)
            }

            person.saveBalance();
        }




    

        public static void inputChoice(ref String choice)
        {
            Console.WriteLine("Ваш выбор: чёт/нечёт:");
            choice = Console.ReadLine();  // выбор пользователя
        }

        public static void inputBet(ref int bet, Balance balance)
        {
            Console.WriteLine("Ваш баланс = " + balance.getBalance());
            Console.WriteLine("Введите вашу ставку:");
            bet = Int32.Parse(Console.ReadLine());
        }

        public static bool checkBetValue(int bet, Balance balance)
        {
            if (bet > balance.getBalance() || bet <= 0)
            {
                Console.WriteLine("Ставка не верна!");
                return false;
            }

            return true;
        }

        public static bool checkResult(String choice, Balance balance, int bet)
        {
            int randomChoice = new Random().Next(0, 2);  // рандомный выбор программы

            // проверка на ввод
            if (!choice.Equals("чёт") && !choice.Equals("нечёт")) return false;
            // выигрыш
            else if (choice.Equals("чёт") && randomChoice == 0 || choice.Equals("нечёт") && randomChoice == 1)
            {
                Console.WriteLine("Вы выиграли!");
                balance.addBalance(bet);
            }
            // проигрыш
            else
            {
                Console.WriteLine("Вы проиграли!");
                balance.reduceBalance(bet);
            }

            return true;
        }

        public static bool isBalanceEmpty(Balance balance)
        {
            if (balance.getBalance() <= 0) { 
                Console.WriteLine("У вас нет средств(");
                return true;
            }

            return false;
        }


        public static bool exitFromApp()
        {
            Console.WriteLine("Для завершения игры введите: \"я добровольно отказываюсь от " +
                "участия в текущей игре и подтверждаю, что осознаю все последствия принятого мною решения\"");
            Console.WriteLine("Для продолжения нажмите на любой символ");
            return Console.ReadLine().Equals("я добровольно отказываюсь от " +
                "участия в текущей игре и подтверждаю, что осознаю все последствия принятого мною решения");
        }
    }




    public class Balance
    {
        private int balance = 10000;

        public int getBalance() => balance;

        public void addBalance(int balance)
        {
            this.balance += balance;
        }

        public void reduceBalance(int balance)
        {
            this.balance -= balance;
        }
    }


    public class Person : Balance
    {
        // сохранение баланса
        public void saveBalance()
        {

        }
    }
}
