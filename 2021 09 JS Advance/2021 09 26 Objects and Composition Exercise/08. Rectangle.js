function solve(w, h, c) {
    let rectangle = {
        width: w,
        height: h,
        color: c.charAt(0).toUpperCase() + c.slice(1),
    }

    rectangle.calcArea = () => {
        return rectangle.width * rectangle.height
    };

    return rectangle;
}

console.log(solve(4, 5, 'red').width);
console.log(solve(4, 5, 'red').height);
console.log(solve(4, 5, 'red').color);
console.log(solve(4, 5, 'red').calcArea());
