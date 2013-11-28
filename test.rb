fruitMap = {}
s = "桔子"
str = <<CODE_STR
fruitMap["苹果"] = "苹果"
fruitMap["平锅"] = "苹果"
fruitMap["apple"] = "苹果"
CODE_STR
eval(str)
puts fruitMap["苹果"]
puts fruitMap["平锅"]
puts fruitMap["apple"]
puts fruitMap["123123"]
puts 12