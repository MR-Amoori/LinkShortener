

<h1 align="center"><b>
  Link Shortener | کوتاه کننده لینک
</br>
</b></h1>

<p align="center">
  یک پروژه ساده و کارآمد کوتاه کننده لینک که با ASP.NET Core ساخته شده است.
  <br />
  <br />
  <a href="https://github.com/MR-Amoori/LinkShortener"><strong>مشاهده پروژه »</strong></a>
  <br />
  <br />
  <img src="https://img.shields.io/github/stars/MR-Amoori/LinkShortener?style=for-the-badge" />
  <img src="https://img.shields.io/github/forks/MR-Amoori/LinkShortener?style=for-the-badge" />
  <img src="https://img.shields.io/github/license/MR-Amoori/LinkShortener?style=for-the-badge" />
</p>

---

<div dir="rtl">

## 📖 درباره پروژه (فارسی)

این پروژه یک سرویس کوتاه کننده لینک است که به کاربران اجازه می‌دهد URL های طولانی را به یک لینک کوتاه و منحصر به فرد تبدیل کنند. این اپلیکیشن با استفاده از **ASP.NET Core MVC** برای ساختار وب و **Entity Framework Core** برای تعامل با پایگاه داده توسعه داده شده است. هدف اصلی این پروژه، ارائه یک راه حل ساده، سریع و متن‌باز برای مدیریت لینک‌ها است.

### ✨ قابلیت‌ها

- **کوتاه کردن لینک:** تبدیل هر URL معتبر به یک لینک کوتاه.
- **تولید توکن منحصر به فرد:** برای هر لینک یک شناسه (توکن) کوتاه و یکتا تولید می‌شود.
- **ریدایرکت سریع:** انتقال سریع کاربر از لینک کوتاه به آدرس اصلی.
- **طراحی ساده:** رابط کاربری تمیز و ساده برای بهترین تجربه کاربری.
- **پایگاه داده:** استفاده از Entity Framework Core برای ذخیره و بازیابی لینک‌ها.

### 🛠️ تکنولوژی‌های استفاده شده

- **ASP.NET Core 6:** فریمورک اصلی برای توسعه وب اپلیکیشن.
- **Entity Framework Core 6:** برای کار با پایگاه داده (ORM).
- **SQL Server:** پایگاه داده پیش‌فرض (قابل تغییر در `appsettings.json`).
- **MVC Pattern:** برای جداسازی منطق برنامه و رابط کاربری.
- **HTML/CSS/Bootstrap:** برای طراحی رابط کاربری.

</div>

---

<div dir="ltr">

## 📖 About The Project (English)

This project is a link shortening service that allows users to convert long URLs into short, unique links. This application is developed using **ASP.NET Core MVC** for the web structure and **Entity Framework Core** for database interaction. The main goal of this project is to provide a simple, fast, and open-source solution for link management.

### ✨ Features

- **Link Shortening:** Convert any valid URL into a short link.
- **Unique Token Generation:** A unique short token is generated for each link.
- **Fast Redirection:** Quickly redirect users from the short link to the original URL.
- **Simple Design:** A clean and straightforward UI for the best user experience.
- **Database Driven:** Uses Entity Framework Core to store and retrieve links.

### 🛠️ Built With

- **ASP.NET Core 6:** The main framework for web application development.
- **Entity Framework Core 6:** For database operations (ORM).
- **SQL Server:** Default database (can be configured in `appsettings.json`).
- **MVC Pattern:** To separate application logic and UI.
- **HTML/CSS/Bootstrap:** For front-end design.

</div>

---

## 🚀 راه‌اندازی و نصب

برای راه‌اندازی پروژه به صورت لوکال، مراحل زیر را دنبال کنید.

<div dir="rtl">

### پیش‌نیازها

- **[.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)** یا نسخه بالاتر.
- یک سرور پایگاه داده مانند **SQL Server** (یا هر پایگاه داده دیگری که توسط EF Core پشتیبانی می‌شود).

### مراحل نصب

۱. **کلون کردن مخزن:**
   ```sh
   git clone [https://github.com/MR-Amoori/LinkShortener.git](https://github.com/MR-Amoori/LinkShortener.git)
   ```sh
   cd LinkShortener
   ```

۲. **پیکربندی پایگاه داده:**
   - فایل `appsettings.json` را باز کنید.
   - رشته اتصال (Connection String) خود را در بخش `ConnectionStrings` قرار دهید.
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=LinkShortenerDB;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
     ```

۳. **اعمال Migration ها:**
   - دستور زیر را در ترمینال یا Package Manager Console اجرا کنید تا پایگاه داده و جداول آن ساخته شوند.
     ```sh
     dotnet ef database update
     ```

۴. **اجرای پروژه:**
   - با استفاده از دستور زیر، پروژه را اجرا کنید.
     ```sh
     dotnet run
     ```
   - اپلیکیشن بر روی آدرس `https://localhost:5001` (یا آدرس مشابه) اجرا خواهد شد.

</div>

## 🤝 مشارکت در پروژه

مشارکت شما باعث دلگرمی ماست! اگر مایل به همکاری هستید، لطفاً یک `fork` از پروژه بگیرید، تغییرات خود را اعمال کرده و یک `Pull Request` ارسال کنید.

۱. پروژه را **Fork** کنید.
۲. یک شاخه جدید برای قابلیت خود بسازید (`git checkout -b feature/AmazingFeature`).
۳. تغییرات خود را **Commit** کنید (`git commit -m 'Add some AmazingFeature'`).
۴. به شاخه خود **Push** کنید (`git push origin feature/AmazingFeature`).
۵. یک **Pull Request** باز کنید.

## 📜 لایسنس

این پروژه تحت لایسنس MIT منتشر شده است. برای اطلاعات بیشتر فایل `LICENSE` را مشاهده کنید.

## 📧 تماس / Contact

محمدرضا عموری - [وبسایت](https://mramoori.ir/) - mohamad.reza.amoori99@gmail.com

لینک پروژه: [https://github.com/MR-Amoori/LinkShortener](https://github.com/MR-Amoori/LinkShortener)
