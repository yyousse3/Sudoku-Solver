board = [
    [7, 8, 0, 4, 0, 0, 1, 2, 0],
    [6, 0, 0, 0, 7, 5, 0, 0, 9],
    [0, 0, 0, 6, 0, 1, 0, 7, 8],
    [0, 0, 7, 0, 4, 0, 2, 6, 0],
    [0, 0, 1, 0, 5, 0, 9, 3, 0],
    [9, 0, 4, 0, 0, 0, 0, 0, 5],
    [0, 7, 0, 3, 0, 0, 0, 1, 2],
    [1, 2, 0, 0, 0, 7, 4, 0, 0],
    [0, 4, 9, 2, 0, 6, 0, 0, 7]
]


def solve(board):
    find = findEmpty(board)
    if not find:
        return True
    else:
        row, col = find

    for i in range(1, 10):
        if valid(board, i, (row, col)):
            board[row][col] = i

            if solve(board):
                return True

        board[row][col] = 0

    return False


def valid(board, num, pos):
    for i in range(9):
        if board[pos[0]][i] == num and pos[1] != i:
            return False

    for i in range(9):
        if board[i][pos[1]] == num and pos[0] != i:
            return False

    boxX = pos[1]//3
    boxY = pos[0]//3

    for i in range(boxY * 3, boxY*3 + 3):
        for y in range(boxX*3, boxX*3 + 3):
            if board[i][y] == num and (i, y) != pos:
                return False

    return True


def printBoard(board):

    for i in range(10):
        row = ""
        if i % 3 == 0:
            print('- - - - - - - - - - -')
            if i == 9:
                break

        for y in range(10):
            if y % 3 == 0:
                row += "|"
                if y == 9:
                    break

            row += str(board[i][y]) + " "
        print(row)


def findEmpty(board):
    for i in range(9):
        for y in range(9):
            if board[i][y] == 0:
                return (i, y)
    return None


printBoard(board)
solve(board)
printBoard(board)
