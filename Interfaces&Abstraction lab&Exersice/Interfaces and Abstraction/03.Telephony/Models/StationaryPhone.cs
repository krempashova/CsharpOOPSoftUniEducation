using Telephony.Models.Interfaces;

namespace Telephony.Models;

public class StationaryPhone : IStatiunaryPhone
{
    public string Call(string phoneNumber)
    {
        if(!IsValidPhoneNumber(phoneNumber))
        {
            throw new ArgumentException("Invalid number!");
        }
        return $"Dialing... {phoneNumber}";
      
    }

    private bool IsValidPhoneNumber(string phoneNumber)
       => phoneNumber.All(ch => char.IsDigit(ch)) ;
}
