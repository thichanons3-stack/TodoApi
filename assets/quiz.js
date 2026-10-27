/* ============================================================
   quiz.js — reusable inline quiz widget
   ใช้ร่วมกันทุกบทเรียน ไม่พึ่ง library ใดๆ

   Usage (HTML contract):
     <div class="quiz" data-best-key="lesson-1">        <!-- optional: localStorage key -->
       <p class="quiz-score"></p>                        <!-- optional -->
       <div class="q">
         <p class="prompt">คำถาม</p>
         <div class="opts">
           <button class="opt" data-correct>คำตอบที่ถูก</button>
           <button class="opt">คำตอบที่ผิด</button>
         </div>
         <p class="feedback" hidden>อธิบายเหตุผล — จะแสดงหลังตอบ</p>
       </div>
     </div>
   ใส่ <script src="../assets/quiz.js"></script> ก่อน </body>
   ============================================================ */

(function () {
  "use strict";

  document.querySelectorAll(".quiz").forEach(function (quiz) {
    var questions = quiz.querySelectorAll(".q");
    var total = questions.length;
    var score = 0;
    var answered = 0;

    var scoreEl = quiz.querySelector(".quiz-score");
    var bestKey = quiz.getAttribute("data-best-key");

    function renderScore(final) {
      if (!scoreEl) return;
      var text = "ตอบถูก " + score + " / " + total;
      if (final && bestKey) {
        var best = 0;
        try {
          best = Number(localStorage.getItem(bestKey)) || 0;
          if (score > best) {
            best = score;
            localStorage.setItem(bestKey, String(score));
          }
        } catch (e) { /* localStorage unavailable (e.g. file://) — ignore */ }
        if (best > 0) text += " · สถิติส่วนตัวของคุณ: " + best;
      }
      scoreEl.textContent = text;
    }

    questions.forEach(function (q) {
      var opts = q.querySelectorAll(".opt");
      var feedback = q.querySelector(".feedback");

      opts.forEach(function (btn) {
        btn.addEventListener("click", function () {
          // lock this question
          opts.forEach(function (b) {
            b.disabled = true;
            if (b.hasAttribute("data-correct")) b.classList.add("correct");
          });

          var isCorrect = btn.hasAttribute("data-correct");
          if (!isCorrect) btn.classList.add("wrong");

          if (feedback) {
            feedback.hidden = false;
            feedback.classList.add("shown", isCorrect ? "good" : "bad");
          }

          if (isCorrect) score++;
          answered++;
          renderScore(answered === total);
        });
      });
    });

    renderScore(false);
  });
})();
