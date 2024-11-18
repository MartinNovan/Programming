class P {
  constructor(n, a) {
      this.n = n;
      this.a = a;
  }

  d() {
      console.log(this.n + " is " + this.a + " years old.");
  }
}

let p = new P("Alice", 30);
p.d();
