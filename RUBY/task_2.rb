#1.

def min_max(array)
  array = array.sort
  puts array.at(0) + array.at(1) + array.at(2) + array.at(3)
  puts array.at(1) + array.at(2) + array.at(3) + array.at(4)
end

min_max([2, 8, 3, 5, 1])

#2.

def decimal(str)
  size = str.size
  res = 0
  i = 1
  for a in str.split('')
    if a.to_i != 0 and a.to_i != 1
      raise "ArgumentError: this is not a binary number"
    end
    res += a.to_i * 2**(size-i)
    i += 1
  end
  puts res
end

decimal("101")

#3.

def count_words(str)
  array = str.split(" ")

  puts array.group_by(&:itself).transform_values(&:count)
end

count_words("olly olly come here free")