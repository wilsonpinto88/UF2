using Parquímetro;

string[] orderedMenuIds = new string[] { "welcome", "chooseArea", "thankYou" };
int lastMenu = 0;
Payment payment = new();

while (true)
{
    Menu menu = new(orderedMenuIds[lastMenu], payment);
    double selectedOption = UI.PrintMenu(menu, 0, DateTime.Now);

    if (userWantsToGoBack(selectedOption))
    {
        continue;
    }

    switch (orderedMenuIds[lastMenu])
    {
        case "welcome":
            // welcome menu only has 1 option so we just want to continue to next menu
            lastMenu++;
            payment.credits = 0;
            break;

        case "chooseArea":
            lastMenu++;
            payment.credits = 0;

            Area[] areas = { new(1, 1.15, 45), new(2, 1, 120), new(3, 0.62, null) };

            // Continue until user wants to finalize payment or go back
            while (true)
            {
                menu = new("area", areas[(int)selectedOption - 1]);
                payment.area = areas[(int)selectedOption - 1];
                double selectedPaymentOption = UI.PrintMenu(menu, payment.credits, payment.GetExitTime());
                if (userWantsToGoBack(selectedPaymentOption))
                {
                    break;
                }
                if (selectedPaymentOption == 9)
                {
                    break;
                }
                payment.credits = Math.Round(payment.credits + selectedPaymentOption, 2);
            }
            break;

        case "thankYou":
            lastMenu = 0;
            break;
    }
}

bool userWantsToGoBack(double option)
{
    // Go back to previous menu
    if (option == 10)
    {
        lastMenu--;
        return true;
    }
    // Go back to main menu
    if (option == 11)
    {
        lastMenu = 0;
        return true;
    }
    return false;
}

// O valor introduzido excede o tempo de estacionamento permitido (45min) -> Troco [Zona 1 e 2]