namespace Parquímetro
{
    public class Menu
    {
        public string id;
        public string title = "";
        public string[] options = new string[] { };
        public Area? area;

        public Menu(string id, Payment payment)
        {
            this.id = id;

            switch (id)
            {
                case "welcome":
                    CreateWelcomeMenu();
                    break;
                case "chooseArea":
                    CreateChooseAreaMenu();
                    break;
                case "thankYou":
                    CreateThankYouMenu(payment);
                    break;
                case "administrator":
                    CreateAdminMenu();
                    break;
            }
        }

        public Menu(string id, Area area)
        {
            this.id = id;
            this.area = area;

            CreateAreaMenu(area);
        }

        public bool AddFinalizePayment()
        {
            return id == "area";
        }

        public bool AddBackToPreviousMenu()
        {
            return id != "welcome" && id != "thankYou";
        }

        public bool AddBackToMainMenu()
        {
            return id != "welcome";
        }

        public bool AddFinalTicket()
        {
            return id == "thankYou";
        }

        private void CreateWelcomeMenu()
        {
            title = "Bem Vindo!";
            options = new string[] { "Estacionar" };
        }

        private void CreateAdminMenu()
        {
            title = "Área de Administrador";
            options = new string[] { "Consultar ocupação", "Ver histórico" };
        }

        private void CreateChooseAreaMenu()
        {
            title = "Escolha uma zona";
            options = new string[] { "Zona 1", "Zona 2", "Zona 3" };
        }

        private void CreateAreaMenu(Area area)
        {
            string maxTime = area.maxTime != null ? $"{area.maxTime}min" : "ilimitado";
            title = $"Insira moeda | Tempo máximo: {maxTime} | Valor à hora: {area.hourPrice} euros";
            options = new string[] { "0.01", "0.02", "0.05", "0.10", "0.20", "0.50", "1.00", "2.00" };
        }

        private void CreateThankYouMenu(Payment payment)
        {
            DateTime exitTime = payment.GetExitTime();
            title = $"Obrigado pela sua visita!  Hora de saída: {Time.GetDate(exitTime)} {Time.GetHours(exitTime)}  Total: {payment.credits} euros  Troco: {payment.change} euros";
            options = new string[] { };
        }

    }
}