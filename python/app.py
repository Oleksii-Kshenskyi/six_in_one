import sys


class TwoNums(object):
    def __init__(self, x, y):
        self.x = x
        self.y = y

    def sum(self):
        return self.x + self.y

    def mul(self):
        return self.x * self.y

    def pow(self):
        return self.x ** self.y


def main(argv):
    n = TwoNums(3, 4)
    print("Sum: ", n.sum())
    print("Mul: ", n.mul())
    print("Pow: ", n.pow())


if __name__ == "__main__":
    main(sys.argv)
