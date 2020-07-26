class Algorithm:
  def __init__(self):
       return

  def process(self, n, f, t, a):
      if(n == 1):
          print('Move Disk 1 from the ', f, ' rod to the ', t, ' rod.')
          return

      self.process(n - 1, f, a, t)
      print('Move Disk', n,' from the ', f, ' rod to the ', t, ' rod.')
      self.process(n - 1, a, t, f)

  def solve(self, num):
      self.process(num, 'first', 'last', 'middle')

a = Algorithm()
a.solve(5)
