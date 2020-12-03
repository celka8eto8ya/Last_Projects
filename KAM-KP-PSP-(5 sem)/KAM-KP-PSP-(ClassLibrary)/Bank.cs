namespace KAM_KP_PSP__ClassLibrary_
{
    public static class Bank
    {
        // Adress of Server
        public static string ServerAdress;

        // Port of Server
        public static int ServerPort;






        // присваивается во время "входа"
        public static string NameOfStorage;

        // необходима для удаления строки из таблицы БД
        public static string AccessInDB;

        // необходима для удаления строки из таблицы БД
        public static int IdOfCurrentStorage;




        // number of port for Method "SendMessage"
        public static int portNumber;
        // number of port for Method "SendMessage"
        public static string allMessage;
    }
}
