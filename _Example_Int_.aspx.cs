using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text; //for Encoding
using System.Security.Cryptography; //for SHA1

public partial class _Example_Int_ : System.Web.UI.Page
{
    /* == initialisation == */

    protected void Page_Load(object sender, EventArgs e)
    {
        //-- Set Values (these would be pulled from DB or a previous page). -- //

        //- Customer/Order Details - //
        string strUserTitle = "Mr";                         // Customer details
        string strUserFirstname = "Edward";
        string strUserSurname = "Shopper";
        string strBillHouseNumber = "123";                  // Address Details
        string strAd1 = "Penny Lane";
        string strAd2 = "Central Areas";
        string strBillTown = "Middlehampton";               // Bill Town
        string strBillCountry = "England";                  // Bill Country
        string strPcde = "NN4 7SG";                         // Postcode
        string strContactTel = "01604 567 890";             // Contact Telephone number
        string strShopperEmail = "Mr.E.Shopper@email.com";  // shopper Email
        string strShopperLocale = "en_GB";                  // shopper locale
        string strCurrencyCode = "GBP";                     // CurrecncyCode

        string strAddressline1n2 = strBillHouseNumber + " " + strAd1 + ", " + strAd2;           // Concatenated Address eg 123 Penny Lane Central Areas
        string strCustomerName = strUserTitle + " " + strUserFirstname + " " + strUserSurname;  // Concatenated Customer Name eg Mr Edward Shopper

        string strPaymentAmount = "100";                    // This is 1 pound (100p)
        string strOrderDataRaw = "HDTV - AVTV3000";         // Order description
        string strOrderID = "ORD1234567Y";                  // Order Id 	- **needs to be unique**

        //- integration user details - //
        string strPW = "MyShaInPassPhrase";               // Update with the details you entered into back office
        string strPSPID = "MyPSPID";                      // update with the details of the PSPID you were supplied with


        //- payment design options - '//
        string strTXTCOLOR = "#005588";                             // Page Text Colour
        string strTBLTXTCOLOR = "#005588";                          // Table Text Colour
        string strFONTTYPE = "Helvetica, Arial";                    // fonttype
        string strBUTTONTXTCOLOR = "#005588";                       // Button Text Colour
        string strBGCOLOR = "#d1ecf3";                              // Page Background Colour
        string strTBLBGCOLOR = "#ffffff";                           // Table BG Colour
        string strBUTTONBGCOLOR = "#cccccc";                        // Button Colour
        string strTITLE = "Merchant Shop - Secure Payment Page";    // Title
        string strLOGO = "https://www.merchantsite.co.uk/images/SimpleLogo.JPG";    // logo location
        string strPMLISTTYPE = "1";                                 // Payment Method List type

        //= create string to hash (digest) using values of options/details above. MUST be in field alphabetical order!
        string plainDigest =
        "AMOUNT=" + strPaymentAmount + strPW +
        "BGCOLOR=" + strBGCOLOR + strPW +
        "BUTTONBGCOLOR=" + strBUTTONBGCOLOR + strPW +
        "BUTTONTXTCOLOR=" + strBUTTONTXTCOLOR + strPW +
        "CN=" + strCustomerName + strPW +
        "COM=" + strOrderDataRaw + strPW +
        "CURRENCY=" + strCurrencyCode + strPW +
        "EMAIL=" + strShopperEmail + strPW +
        "FONTTYPE=" + strFONTTYPE + strPW +
        "LANGUAGE=" + strShopperLocale + strPW +
        "LOGO=" + strLOGO + strPW +
        "ORDERID=" + strOrderID + strPW +
        "OWNERADDRESS=" + strAddressline1n2 + strPW +
        "OWNERCTY=" + strBillCountry + strPW +
        "OWNERTELNO=" + strContactTel + strPW +
        "OWNERTOWN=" + strBillTown + strPW +
        "OWNERZIP=" + strPcde + strPW +
        "PMLISTTYPE=" + strPMLISTTYPE + strPW +
        "PSPID=" + strPSPID + strPW +
        "TBLBGCOLOR=" + strTBLBGCOLOR + strPW +
        "TBLTXTCOLOR=" + strTBLTXTCOLOR + strPW +
        "TITLE=" + strTITLE + strPW +
        "TXTCOLOR=" + strTXTCOLOR + strPW +
        "";

        //-- insert payment details into hidden fields -- //
        AMOUNT.Value = strPaymentAmount;            // PaymentAmmount : (100 pence)
        CN.Value = strCustomerName;                 // Customer Name
        COM.Value = strOrderDataRaw;                // OrderDataRaw (order description)
        CURRENCY.Value = strCurrencyCode;           // CurrecncyCode
        EMAIL.Value = strShopperEmail;              // shopper Email
        FONTTYPE.Value = strFONTTYPE;               // fonttype
        LANGUAGE.Value = strShopperLocale;          // shopper locale
        LOGO.Value = strLOGO;                       // logo location
        ORDERID.Value = strOrderID;                 // *this ORDER ID*
        OWNERADDRESS.Value = strAddressline1n2;     // AddressLine2
        OWNERCTY.Value = strBillCountry;            // Bill Country
        OWNERTELNO.Value = strContactTel;           // Contact Telephone number
        OWNERTOWN.Value = strBillTown;              // Bill Town
        OWNERZIP.Value = strPcde;                   // Postcode
        PMLISTTYPE.Value = strPMLISTTYPE;           // Payment Method List type
        PSPID.Value = strPSPID;                     // *Your PSPID*
        BGCOLOR.Value = strBGCOLOR;                 // Page Background Colour
        BUTTONBGCOLOR.Value = strBUTTONBGCOLOR;     // Button Colour
        BUTTONTXTCOLOR.Value = strBUTTONTXTCOLOR;   // Button Text Colour
        TBLBGCOLOR.Value = strTBLBGCOLOR;           // Table BG Colour
        TBLTXTCOLOR.Value = strTBLTXTCOLOR;         // Table Text Colour
        TITLE.Value = strTITLE;                     // Title
        TXTCOLOR.Value = strTXTCOLOR;               // Page Text Colour

        SHASign.Value = SHA1HashData(plainDigest);  // Hashed String of plain digest put into sha sign using SHA1HashData function

    }

    /* == Functions == */

    private string SHA1HashData(string data) // encryptor 
    {
        SHA1 Hasher = SHA1.Create();                                        // Create instance of Hasher
        byte[] NCodedtxt = Encoding.Default.GetBytes(data);                 // Encodes characters in string to a sequence of bytes
        byte[] HashedDataBytes = Hasher.ComputeHash(NCodedtxt);             // Encodes byte data with SHA1


        StringBuilder HashedDataStringBldr = new StringBuilder();           // Create new instance of StringBuilder to save hashed data back into (convert byte stream to string)
        for (int i = 0; i < HashedDataBytes.Length; i++)                    // Loop through each encoded byte and add it to the returnValue string
        {
            HashedDataStringBldr.Append(HashedDataBytes[i].ToString("X2")); // Returns a string of 2-digit hexadecimal values
        }

        return HashedDataStringBldr.ToString();                             // Send the sha1 hex encoded string back 
    }
}