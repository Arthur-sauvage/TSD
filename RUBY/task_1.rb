#1.

def factorial(x)
  puts (1..x).inject(1) { |result, element| result * element }
end

factorial 5

#2.

class Integer
   def factorial
    if (self < 0)
      raise "Runtime error: cannot count factorial for negative number"
    end
    puts (1..self).inject(1) { |result, element| result * element }
  end
end

5.factorial

#3.

module InstanceModule
  def square
    puts self * self
  end
end

class Integer
  include InstanceModule
end

5.square

#4.

module ClassModule
  def sample(x)
    if (x < 0)
      raise "ArgumentError: the number must be positive"
    end
    res = Array.new(0)
    
    for a in 1..x do
      res.push(rand(10))
    end
    puts res
  end
end

class Integer
  extend ClassModule
end

Integer.sample(10)