class Algorithm {
    constructor(num) {
        this.numOfDisks = num;
    }

    solve() {
        this.process(this.numOfDisks, 'first', 'last', 'middle');
    }

    process(n, f, t, a) {
        if (n == 1) {
            this.output('Move Disk 1 from the ' + f + ' rod to the ' + t + ' rod.')
            return
        }

        this.process(n - 1, f, a, t);
        this.output('Move Disk ' + n + ' from the ' + f + ' rod to the ' + t + ' rod.');
        this.process(n - 1, a, t, f);
    }

    output(text) {
        console.log(text);
    }
}
