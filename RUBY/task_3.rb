#1.

class Clock

  def initialize(h, m, s)
    @@hours = h
    @@minutes = m
    @@secondes = s

  end

  def self.hours
    @@hours
  end

  def self.minutes
    @@minutes
  end

  def self.secondes
    @@secondes
  end

  def print
    puts @@hours.to_s + ":" + @@minutes.to_s + ":" + @@secondes.to_s
  end

  def +(x)
    Clock.new((@@hours + x/60)%24, @@minutes + x%60, @@secondes)
  end

  def -(x)
    Clock.new((@@hours - x/60)%24, @@minutes - x%60, @@secondes)
  end

  def ==(c)
    puts @@hours == c.hours
  end
  
end

clock = Clock.new(1, 0, 0)
clock.print  # The current time is 10:00:00
clock += 30
clock.print  # The current time is 10:30:00
clock -= 135
clock.print  # The current time is 10:30:00
clock2 = Clock.new(10, 30, 0)
clock2 == Clock.new(10, 30, 0)  # true