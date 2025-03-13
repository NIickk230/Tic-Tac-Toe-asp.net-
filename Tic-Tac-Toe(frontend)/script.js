const boardElement = document.getElementById("game-board");
const resetButton = document.getElementById("reset-button");

async function fetchBoard() {
    const response = await fetch("https://localhost:7084/api/_game/board")
    const data = await response.json();
    renderBoard(data.board)
}

async function makeMove(row, col){
    const response = await fetch("https://localhost:7084/api/_game/move", {
        method: "POST",
        headers: { "content-Type": "application/json" },
        body: JSON.stringify({ row, col })
    });

    const data = await response.json();
    if(data.message){
        alert(data.message)
    }
    renderBoard(data.board)
}

async function resetGame() {
    await fetch("https://localhost:7084/api/_game/reset", {method: "POST"});
    fetchBoard();
}

function renderBoard(board) {
    boardElement.innerHTML = "";
    for(let i = 0; i < 3; i++){
        for(let j = 0; j < 3; j++){
            const cell = document.createElement("div")
            cell.classList.add("cell")
            cell.textContent = board[i][j];
            cell.addEventListener("click", () => makeMove(i, j))
            boardElement.appendChild(cell)
        }    
    }
}

resetButton.addEventListener("click", resetGame)

fetchBoard();