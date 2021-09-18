function solve(arr) {
    const board = [0, 0, 0].map(x => ["false", "false", "false"])
    let player = "X"

    function isWinningMove(board, row, place) {
        return (
            board[row].every(x => x === player) ||
            board
                .reduce((a, v) => {
                    a.push(v[place])
                    return a
                }, [])
                .every(x => x === player) ||
            [board[0][0], board[1][1], board[2][2]].every(x => x === player) ||
            [board[0][2], board[1][1], board[2][0]].every(x => x === player)
        )
    }

    const printBoard = board => console.log(board.map(x => x.join("\t")).join("\n"))

    for (let i = 0; i < arr.length; i++) {
        const [row, place] = arr[i].split(" ").map(Number)

        if (board[row][place] !== "false") {
            console.log("This place is already taken. Please choose another!")
            continue
        }
        board[row][place] = player

        if (isWinningMove(board, row, place)) {
            console.log(`Player ${player} wins!`)
            printBoard(board)
            break
        }

        if (board.every(x => x.every(y => y !== "false"))) {
            console.log("The game ended! Nobody wins :(")
            printBoard(board)
            break
        }

        player = player === "X" ? "O" : "X"
    }
}

console.log(solve(["0 1", "0 0","0 2", "2 0","1 0","1 1","1 2","2 2","2 1","0 0"]));
console.log(solve(["0 0", "0 0","1 1","0 1","1 2","0 2","2 2","1 2","2 2","2 1"]));
console.log(solve(["0 1","0 0","0 2","2 0","1 0","1 2","1 1","2 1","2 2","0 0"]));
