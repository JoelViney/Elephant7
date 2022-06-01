
# Elephant 7

This nuget package provides a quick and easy way to generate data for integration tests.

It can be found on Nuget by searching for 'Elephant7'

## Technologies Used
	* Nuget
	* MSTest
	* Moq

## Why Elephant7
Seems like a cool name?

## Usage
using Elephant7;

var random = new Random();

Most of the random calls can be provided with a a minimum and maximum length or size parameters.

### Text 
    var word = random.NextWord();
    var sentence = random.NextSentence();
    var paragraph = random.NextParagraph();
    var code = random.NextCode();           // Returns a random combination of characters and numbers.
    var heading = random.NextHeading();     // Returns a heading like a news story or document heading

    var businessName = random.NextBusinessName();

### Numbers
    var intValue = random.NextNumber(1, 10);
    var intCurvedValue = random.NextNumberCurved(1, 10);
    var currencyValue = random.NextCurrency();
    var decimalValue = random.NextDecimal();

##  Other Data Types
    var percentageValue = random.NextPercentage();
    var boolValue = random.NextBoolean();
    var dateTimeValue = random.NextDateTime();
    
## Other
    var abn = random.NextAbn();                  // Australian ABN
    var mobileNumber = random.NextMobileNumber(); // Australian mobile number
    var tfn = random.NextTaxFileNumber();   // Australian TFN
    
    var enumValue = random.NextEnum<DayOfWeek>();

    var element = rnd.NextListItem<string>(new string[] { "John", "Jack", "Billy", "Kevin" });

## Custom Objects
    var address = random.NextAddress(); // Returns a well formatted Australian Address.

    var person = random.NextPerson();   // With Title, Name, Gender, Email, Date of Birth
