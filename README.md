# YummyFood

## appsetting 
```json 
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnenction": "Host=localhost;Port=5432;Database=YummyFoodDb;User Id=YOUR_USERID;Password=YOUR_PASSWORD;"
  },
  "JWTSettings": {
    "ValidAudence": "https://localhost:4200/",
    "ValidIssuer": "https://localhost:7146/",
    "Secret": "YOUR_SECRET_KEY",
    "Expire": "60"
  },
  "EmailSettings": {
    "MailServer": "smtp.gmail.com",
    "MailPort": 587,
    "SenderName": "YummyFood",
    "Sender": "YOUR_EMAIL",
    "Password": "YOUR_PASSWORD"
  },
  "MessangerAgentSettings": {
    "Email": "YOUR_EMAIL_IN_ESKIZ",
    "Key": "YOUR_KEY_IN_ESKIZ"
  }
}

```
