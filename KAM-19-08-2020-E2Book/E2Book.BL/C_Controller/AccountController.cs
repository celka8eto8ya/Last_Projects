using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2Book.BL.C_Controller
{
    public class AccountController
    {
        public static void CheckUnique(ref bool answerPar)
        {
            // проверка уникальности имени счет
            // десериализация + фор на проверку совпадений
            // вывод bool
        }

        public static void Convert(string currency1Par, double sumCurrency1Par, string currency2Par,  ref double answerPar)
        {
            // КОНЕРТИРОВНАИЕ ВАЛЮТЫ
            // УМНОЖЕНИЕ ИЗНАЧАЛЬНОЙ СУММЫ НА НОВЫЙ КОЭФФИЦИЕНТ
            // ТУТ ВОЗМОЖНО ИСПОЛЬЗЩОВАТЬ ПРОТОКОЛ ДЛЯ ДОСТУПА К САЙТУ (ВЗЯТЬ МЕТОД ИЗ ЛАБЫ КОТОРУЮ ПИСАЛ)
            // ПРОПИСАТЬ ИСКЛЮЧЕНИЕ НА СЛУЧАЙ ОШИБКИ С ВЫВОДОМ СООБЩЕНИЯ "НЕТ ПОДКЛЮЧЕНИЯ К ИНТЕРНЕТУ"
           
        }
    }
}
