
using Telephony.Models.Interfaces;

namespace Telephony.Models;
public class Smartphone : ISmartPhone
{
    public string BrowseUrl(string url)
    { if(!IsValidURL(url))
        {
            throw new ArgumentException("Invalid URL!");
        }
        return $"Browsing: {url}!";


    }

    private bool IsValidURL(string url)
    => url.All(c => !char.IsDigit(c));

    public string Call(string phoneNumber)
    {
        if(!IsValidPhoneNumber(phoneNumber))
        {
            throw new ArgumentException("Invalid number!");
        }
        return $"Calling... {phoneNumber}";
    }

    private bool IsValidPhoneNumber(string phoneNumber)
    => phoneNumber.All(c => char.IsDigit(c));
}
