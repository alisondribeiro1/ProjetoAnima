const { PDFDocument, rgb } = require('pdf-lib');
const fetch = require('node-fetch');
const fs = require('fs');

async function generateCertificate() {
  const url = 'https://alpaca.rocketseat.com.br/skylab/certificates/pdf/5093982c-1ad3-496a-b699-f690185dda9f';
  const response = await fetch(url);
  const existingPdfBytes = await response.arrayBuffer();

  const pdfDoc = await PDFDocument.load(existingPdfBytes);
  const page = pdfDoc.getPages()[0];

  const { width, height } = page.getSize();

  // Add text to the certificate
  const name = 'John Doe';
  const course = 'Skylab';
  const date = 'July 24, 2023';

  const fontSize = 40;
  const textX = 300;
  const textY = 290;

  page.drawText(name, { x: textX, y: textY, size: fontSize, color: rgb(0, 0, 0) });

  const courseFontSize = 20;
  const courseTextY = textY - 50;

  page.drawText(course, { x: textX, y: courseTextY, size: courseFontSize, color: rgb(0, 0, 0) });

  const dateFontSize = 18;
  const dateTextY = textY - 100;

  page.drawText(date, { x: textX, y: dateTextY, size: dateFontSize, color: rgb(0, 0, 0) });

  // Save the modified PDF
  const modifiedPdfBytes = await pdfDoc.save();
  fs.writeFileSync('certificate.pdf', modifiedPdfBytes);

  console.log('Certificate generated successfully!');
}

generateCertificate();
