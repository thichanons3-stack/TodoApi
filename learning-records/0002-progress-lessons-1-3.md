# 0002 · ความคืบหน้า บทที่ 1–3 + ช่องว่างที่พบและแก้แล้ว

- **วันที่** 2026-10-25
- **ประเภท** Progress record (จดระหว่างทาง ไม่ใช่ผลประเมิน)

## สิ่งที่ส่งมอบแล้ว

- บทที่ 1: ชีวิตหนึ่งของ HTTP Request (pipeline, สองครึ่งของ Program.cs, route matching)
- บทที่ 2: C# essentials (generics, async/await/Task, attributes, constructor+readonly, nullable)
- บทที่ 3: แปลง `TodoItemsController` → Minimal API line-by-line + ตารางแปลง + กับดัก 3 ข้อ
- Reference: 0001 (lifecycle), 0002 (C# cheat sheet), 0003 (ตารางแปลง) + glossary (อัปเดตทุกบท)

## ช่องว่างที่พบระหว่างทำ (แก้แล้ว)

- **Quiz feedback ว่างเปล่าทั้ง 12 ข้อในบท 1–2** — กล่องคำอธิบายขึ้นมาแต่ไม่มีเนื้อหา
  แก้แล้วเมื่อ 2026-10-25: เติมคำอธิบายครบทุกข้อทั้งสองบท และบทที่ 3 เขียนให้ครบตั้งแต่แรก
- บท 3 verify แหล่งอ้างอิง 5 URL ใหม่ (parameter-binding, validation, min-web-api ฯลฯ) → RESOURCES.md

## หลักฐานทดสอบ (ไม่ใช่ความจำ — รันจริงบน .NET 10, 2026-10-25)

1. `MapGroup("/api/todos")` + `MapGet("/")` → จับทั้ง `/api/todos` และ `/api/todos/` (200 ทั้งคู่)
2. สอง endpoint แย่งเส้นทางเดียวกัน → `AmbiguousMatchException` HTTP 500 ทันทีที่มี request
3. `{id:int}` constraint → `/api/todos/abc` ได้ 404

## ยังไม่ได้รับข้อมูลจากผู้เรียน

- **ยังไม่มีรายงานผล quiz บท 1, 2, 3 เลย** (ผู้เรียนสั่ง "บทถัดไป" ต่อเนื่องทั้งสองครั้ง)
- ยังไม่รู้ว่าข้อไหนงงที่สุด → ยังปรับ difficulty ตาม ZPD จริงไม่ได้
- ** action item: ตอนจบบทที่ 3 ต้องถามผล quiz ให้ได้อย่างน้อย 1 ครั้ง ก่อนไปบทที่ 4**

## ผลต่อการสอนขั้นต่อไป

- บทที่ 4 (เทียบ criteria) ควรใช้คำถามวัดความเข้าใจบท 1–3 ก่อนเริ่ม — ถ้ายังไม่มี feedback ให้
  ใส่ quiz ย้อนทบทวน 1–2 ข้อในต้นบท 4
- criteria ที่มีหลักฐานรองรับแล้วจากบท 3: **validation ต้อง `AddValidation()` เอง**
  (ฝั่ง controller ได้ `[ApiController]` ฟรี) — ใช้เป็นข้อแรกในตารางเทียบบทที่ 4

## Revision log

- 2026-10-25: สร้าง record (ความคืบหน้า + gaps)
