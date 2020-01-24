function solve(n, b) {
    let bin = n.toString(2);

    let count = 0;

    for (let i = 0; i < bin.length; i++) {
        if(bin[i] == b) count++;        
    }

    return count;
}

console.log(solve(23, 1));