# Resources

แหล่งเรียนรู้ที่ใช้ประกอบการสอน — ตรวจสอบแล้วเมื่อ **2026-10-24** (verified = เปิดอ่านเนื้อหาจริงแล้ว)

## Official (Microsoft Learn — .NET 10)

- **[APIs overview](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/apis?view=aspnetcore-10.0)** — verified
  หน้าหลักที่ Microsoft ประกาศว่า *For new projects, we recommend using Minimal APIs* พร้อม criteria ว่าเมื่อไรควรใช้ controllers
  → หัวใจของ mission นี้ ใช้เป็น primary source ของคอร์ส
- **[ASP.NET Core middleware](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-10.0)** — verified
  pipeline, Use/Run/Map, ลำดับ middleware ที่ `WebApplication` เพิ่มให้อัตโนมัติ (UseRouting / UseEndpoints)
- **[Minimal APIs quick reference](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-10.0)** — verified (2026-10-25)
  หน้าอ้างอิงหลักของบทที่ 3: routing, parameter binding, ค่า return, route group, validation
- **[Tutorial: Create a Minimal API](https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-10.0)** — verified (2026-10-25) ใช้ตอนบทที่ 3
- **[Parameter binding in Minimal API](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/parameter-binding?view=aspnetcore-10.0)** — verified (2026-10-25)
  กฎ binding ทั้งหมด: route/query/body/DI + ข้อที่ GET ไม่อ่าน body ให้
- **[Validation in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/validation?view=aspnetcore-10.0)** — verified (2026-10-25)
  Minimal API ต้องเรียก `AddValidation()` ไม่งั้น DataAnnotations ไม่วิ่ง — หัวใจ criteria ข้อ validation
- **[Tutorial: Controller-based web API](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-10.0)** — เทียบกับสิ่งที่ผู้เรียนเขียนอยู่แล้ว
- **[Routing](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-10.0)** — ใช้ตอนบทที่ 1 (endpoint routing)

## ชุมชน (สำหรับWisdom — ทดสอบทักษะกับคนจริง)

- **r/dotnet** — มีกระทู้ controllers vs minimal APIs ให้เห็นมุมมองจริงของคนทำงาน
  เช่น [Controllers vs. Minimal APIs — which do you prefer and why](https://www.reddit.com/r/dotnet/comments/1fuzw78/controllers_vs_minimal_apis_which_do_you_prefer)
- **Stack Overflow แท็ก [asp.net-core]** — ไว้ถามคำถามเฉพาะจุด
- **[dotnet/aspnetcore บน GitHub]** — ดูว่า framework จริงทำงานอย่างไร ไว้ตอน advanced

## วิดีโอ / บทความเสริม (ยังไม่ได้ verify เนื้อหาทั้งหมด — ใช้วิจารณญาณ)

- Anderson Godoy — *Minimal APIs vs Controllers in .NET 10: What I Would Use in Production* (Medium, 2026) — มุมมอง production ที่มี nuance ดี

## หลักการเลือกใช้

- **เชื่อ Microsoft docs ก่อน** เสมอสำหรับพฤติกรรมของ framework
- บทความ/Reddit = มุมมอง ไม่ใช่ข้อเท็จจริง — ใช้ประกอบการตัดสินใจเท่านั้น
- ถ้าข้อมูลใน lesson ขัดกับ docs ปัจจุบัน → ให้ถือ docs ใหม่กว่าเสมอ และอัปเดตไฟล์นี้
