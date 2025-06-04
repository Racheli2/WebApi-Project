
# WebApi-Project

פרויקט Web API ב-ASP.NET Core

🌍 This is a Web API project built with ASP.NET Core, using modern architecture, secure JWT authentication, and EF Core for database operations.
🔒 זהו פרויקט API מאובטח עם JWT, גישה למסד נתונים באמצעות EF Core, ותיעוד אינטראקטיבי עם Swagger.

---

## 📦 Features / תכונות עיקריות

* ✅ **JWT Authentication** / אימות משתמשים עם JWT
* ✅ **Entity Framework Core** / גישה למסד נתונים
* ✅ **Swagger/OpenAPI** / תיעוד API
* ✅ **Docker Support** / תמיכה ב-Docker

---

## 🗂️ Structure / מבנה הפרויקט

| Folder         | Description (EN)      | תיאור (עברית)            |
| -------------- | --------------------- | ------------------------ |
| `Controllers/` | API endpoints         | בקרי ה-API               |
| `Models/`      | Data models           | מודלים של נתונים         |
| `Data/`        | DB context and config | קובצי הגדרה למסד הנתונים |
| `Services/`    | Business logic        | לוגיקה עסקית             |

---

## 🚀 Getting Started / התחלה מהירה

### Requirements / דרישות מקדימות:

* [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
* Visual Studio 2022 / VS Code
* Docker (optional / אופציונלי)

### Installation / התקנה:

```bash
git clone https://github.com/Racheli2/WebApi-Project.git
cd WebApi-Project
dotnet restore
dotnet build
dotnet run
```

Visit Swagger at:
🔗 `http://localhost:5000/swagger`

---

## 🐳 Docker Support / הרצה עם Docker

```bash
docker build -t webapi-project .
docker run -d -p 5000:80 webapi-project
```

---

## 🤝 Contributing / תרומות

Pull requests are welcome!
תורמים מתקבלים בברכה – אפשר לפתוח Issue או לשלוח PR.

---

## 📄 License / רישיון

This project is licensed under the MIT License.
הפרויקט מופץ תחת רישיון MIT. לפרטים נוספים עיין בקובץ LICENSE.

---

