# Teaching Notes

## _preferences ผู้เรียน

- สอนเป็น **ภาษาไทย** — ศัพท์เทคนิค (middleware, routing, DI) คงเป็นอังกฤษ + อธิบายไทยกำกับเสมอ
- ระดับ: **เพิ่งเริ่มเรียน C#/.NET** — ห้ามสมมติว่ารู้ async/DI/attribute ต้องปูก่อนใช้เสมอ
- ทำงานจาก **โค้ดจริงในโปรเจกต์นี้** เสมอ ห้ามสอนจากตัวอย่าง abstract
- ชอบตัวอย่างที่จับต้องได้และให้ลองทำทันที (มีแบบฝึกหัดลงมือทำ)

## สถานะการสอน

- 2026-10-24: สร้าง workspace + บทที่ 1 (ชีวิตหนึ่งของ HTTP Request)
- 2026-10-24: สร้างบทที่ 2 (C# essentials จากไฟล์จริง) — ผู้เรียนสั่ง "บทถัดไป" ทันที ยังไม่ได้รายงานผล quiz บทที่ 1
- 2026-10-25: สร้างบทที่ 3 (แปลง TodoItemsController → Minimal API) + **แก้ quiz feedback ที่ว่างเปล่าในบท 1–2 ให้มีคำอธิบายครบทุกข้อ**
- บทถัดไป (วางแผนไว้):
  1. ~~บทที่ 1: request lifecycle~~ ✓
  2. ~~บทที่ 2: C# essentials (async/DI/attribute/generics/nullable)~~ ✓
  3. ~~บทที่ 3: เขียน Minimal API ชุดเดียวกัน (แปลง TodoItemsController line-by-line)~~ ✓
  4. บทที่ 4: เทียบกันบน criteria จริง (validation, filters, OpenAPI, testing, ทีม)
  5. บทที่ 5: ลองของจริงทั้งสองแบบ (รัน + เทส + ดู OpenAPI)
  6. บทที่ 6: ตัดสินใจด้วย decision framework → บันทึก learning record

## สิ่งที่ต้องระวังในโค้ดผู้เรียน (ไว้สอนต่อยอด ไม่ใช่ตอนนี้)

- `CategoriesControllers.cs` มี `Console.WriteLine("Categories: ", categories);` — format string ไม่มี placeholder {0} (ไม่ crash แต่ไม่พิมพ์ค่า)
- `UpdateCategory` รับ entity `Category` ตรงๆ (ไม่ผ่าน DTO) — เป็นตัวอย่างดีตอนสอนเรื่อง validation ของทั้งสองสไตล์
- DTO constructor ใน TodoItemDTO มี logic ซ้ำสองรอบ (if/else ทับบรรทัด assign ก่อนหน้า)
- จุดเหล่านี้ **ห้ามแก้เองโดยไม่ถาม** — ผู้เรียนเป็นเจ้าของโค้ด ใช้เป็นตัวอย่างการสอนเท่านั้น
