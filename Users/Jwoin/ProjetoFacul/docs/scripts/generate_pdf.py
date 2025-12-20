import os
import sys
import io
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
MD = ROOT / 'docs' / 'technical-report.md'
OUT = ROOT / 'docs' / 'technical-report.pdf'

if not MD.exists():
    print(f"Markdown file not found: {MD}")
    sys.exit(2)

md_text = MD.read_text(encoding='utf-8')

# Convert markdown to HTML
try:
    import markdown
    html = markdown.markdown(md_text)
except Exception:
    # minimal conversion: wrap in <pre>
    html = f"<pre>{md_text}</pre>"

# Try WeasyPrint
try:
    from weasyprint import HTML
    HTML(string=html).write_pdf(OUT)
    print(f"Generated PDF using WeasyPrint: {OUT}")
    sys.exit(0)
except Exception as e:
    print("WeasyPrint not available or failed:", e)

# Try xhtml2pdf
try:
    from xhtml2pdf import pisa
    with open(OUT, 'wb') as f:
        pisa_status = pisa.CreatePDF(io.StringIO(html), dest=f)
    if pisa_status.err:
        raise RuntimeError("xhtml2pdf failed to create PDF")
    print(f"Generated PDF using xhtml2pdf: {OUT}")
    sys.exit(0)
except Exception as e:
    print("xhtml2pdf not available or failed:", e)

# Fallback to reportlab (plaintext)
try:
    from reportlab.lib.pagesizes import letter
    from reportlab.pdfgen import canvas
    lines = md_text.splitlines()
    c = canvas.Canvas(str(OUT), pagesize=letter)
    width, height = letter
    y = height - 72
    left = 72
    for line in lines:
        # Simple wrapping
        if y < 72:
            c.showPage()
            y = height - 72
        c.drawString(left, y, line[:1000])
        y -= 14
    c.save()
    print(f"Generated PDF using reportlab fallback (plain text): {OUT}")
    sys.exit(0)
except Exception as e:
    print("Reportlab fallback failed:", e)
    sys.exit(3)
