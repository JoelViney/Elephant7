
# Elephant 7

This nuget package provides a quick and easy way to generate data for integration tests.

It can be found on Nuget by searching for 'Elephant7'

## Technologies Used
	* Nuget
	* .NET Core 2.0
	* MSTest
	* Moq

## Why Elephant7
Seems like a cool name?

## Usage
using Elephant7;

var random = new Random();

Most of the random calls can be provided with a a minimum and maximum length or size parameters.

### Text 
    var wordValue = random.NextWord();
    var sentenceValue = random.NextSentence();
    var paragraphValue = random.NextParagraph();
    var codeValue = random.NextCode();           // Returns a random combination of characters and numbers.
    var headingValue = random.NextHeading();     // Returns a heading like a news story or document heading

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
    var abnValue = random.NextAbn();
    var mobileValue = random.NextMobileNumber();
    var tfnValue = random.NextTaxFileNumber();
    
    var enumValue = random.NextEnum<DayOfWeek>();

    var itemValue = rnd.NextListItem<string>(new string[] { "John", "Jack", "Billy", "Kevin" });

## Custom Objects
    var addressValue = random.NextAddress(); // Returns a well formatted Australian Address.

    var personValue = random.NextPerson();   // With Title, Name, Gender, Email, Date of Birth
