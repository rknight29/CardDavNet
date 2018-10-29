using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDav;
using CardDav.Card;
using CardDav.Response;

namespace CardDavConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string uri = "https://contacts.cloze.com/carddav/addressbooks/randy@sqlsolutionsgroup.com/default/";
            string username = "randy@sqlsolutionsgroup.com";
            string password = "695153079e75aab8dd4590fab2847a91";

            CardDav.Client client = new CardDav.Client(uri,username, password);

            CardDavResponse response = client.Get();

            /** Output the results from the Listing **/

            string results = response.ToString();

            /** Set the client to the proper Address Book server URL **/
            client.SetServer(response.AddressBooks.First().Url.ToString());
            vCard card = client.GetVCard(response.Cards.First().Id);

            results = results + "\r\n\r\n\r\n" + card.ToString();

        }
    }
}