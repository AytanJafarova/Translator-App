function updateFill(word) {
    var selectedRow = word.closest('tr');
    document.getElementById('azeUp').value = selectedRow.cells[1].innerText;
    document.getElementById('azeUpHidden').value = selectedRow.cells[1].innerText;
    document.getElementById('trUp').value = selectedRow.cells[2].innerText;
    document.getElementById('ozbekUp').value = selectedRow.cells[3].innerText;
    document.getElementById('qirgizUp').value = selectedRow.cells[4].innerText;
    document.getElementById('tatarUp').value = selectedRow.cells[5].innerText;
    document.getElementById('turkmenUp').value = selectedRow.cells[6].innerText;
    document.getElementById('uygurUp').value = selectedRow.cells[7].innerText;
    document.getElementById('qazaxUp').value = selectedRow.cells[8].innerText;
}
function deleteWord(word) {
    var selectedRow = word.closest('tr');
    document.getElementById('azeDeleteHidden').value = selectedRow.cells[1].innerText;
}
