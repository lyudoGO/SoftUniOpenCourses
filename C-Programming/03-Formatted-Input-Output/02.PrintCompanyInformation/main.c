#include <stdio.h>
#include <string.h>

int main()
{
    char companyName[31];
    char companyAddress[41];
    char phoneNumber[21];
    char faxNumber[21];
    char webSite[31];
    char managerFirstName[16];
    char managerLastName[16];
    char managerAge[4];
    char managerPhone[21];

    printf("Enter company name: ");
    fgets(companyName, 31, stdin);
    strtok(companyName, "\n");

    printf("Enter company address: ");
    fgets(companyAddress, 41, stdin);
    strtok(companyAddress, "\n");

    printf("Enter company phone: ");
    fgets(phoneNumber, 21, stdin);
    strtok(phoneNumber, "\n");

    printf("Enter company fax: ");
    fgets(faxNumber, 21, stdin);
    strtok(faxNumber, "\n");

    printf("Enter company web: ");
    fgets(webSite, 31, stdin);
    strtok(webSite, "\n");

    printf("Enter manager first name: ");
    fgets(managerFirstName, 16, stdin);
    strtok(managerFirstName, "\n");

    printf("Enter manager last name: ");
    fgets(managerLastName, 16, stdin);
    strtok(managerLastName, "\n");

    printf("Enter manager age: ");
    fgets(managerAge, 4, stdin);
    strtok(managerAge, "\n");

    printf("Enter manager phone: ");
    fgets(managerPhone, 21, stdin);
    strtok(managerPhone, "\n");

    printf("\nCompany: %s\n", (strchr(companyName, '\n') == NULL) ? companyName : "(no name)");
    printf("Address: %s\n", (strchr(companyAddress, '\n') == NULL) ? companyAddress : "(no address)");
    printf("Tel.: %s\n", (strchr(phoneNumber, '\n') == NULL) ? phoneNumber : "(no phone)");
    printf("Fax: %s\n", (strchr(faxNumber, '\n') == NULL) ? faxNumber : "(no fax)");
    printf("Web: %s\n", (strchr(webSite, '\n') == NULL) ? webSite : "(no web)");
    printf("Manager: %s %s ", managerFirstName, managerLastName);
    printf("(Age: %s; Tel: %s)", managerAge, managerPhone);

    return 0;
}
