# encoding: utf-8
fruitTypeRegex = ""
fruitCountRegex = "\\d+(?=\D?\D?[斤个根只])"
fruitUnitRegex = "((?<=\\d)|(?<=\\d\\D)|(?<=\\d\\D\\D))[斤个根只]"
domRegex = "((博雅)|(疏[桐通]?[园圆元]?[ABCDEabcde])|([静京景晶][园圆元]?)|(6[ABCabc])|([丹][枫风凤峰]?))[ABCDEabcde]?.?.?\\d{3}"
nameRegex = "(?<=%).+(?=%)"
orders = Array.new
messages = Array.new
fruitMap = {}
fruitTypeRegexFilePath = "data/" + "fruitTypeRegex.txt"
fruitTypeMapFilePath = "data/" + "fruitTypeMap.rb"
finPath = "message.txt"
foutPath = "orderlist.txt"

class Fruit
	attr_accessor :type, :count, :unit
	def initialize(type, count, unit)
		@type = type
		@count = count
		@unit = unit
	end
end

class Order
	attr_accessor :fruits, :dom, :name
	def initialize(name)
		@name = name
		@fruits = Array.new
	end

	def addFruit(fruit)
		@fruits << fruit
	end
end


puts "初始化"
print "  ->加载水果匹配正则...."
File.open(fruitTypeRegexFilePath, "r:utf-8").each do |line|
	fruitTypeRegex = line
end
puts "完成"
print "  ->加载水果映射列表...."
File.open(fruitTypeMapFilePath, "r:utf-8").each do |line|
	eval(line)
end
puts "完成"


print "  ->打开"
print "message.txt" + "...."
fileString = "";
begin
	fin = File.open(finPath,"r:utf-8")	
	puts "完成"
	puts "初始化结束"
	puts "----开始解析-----"
rescue Exception => e
	puts "打开文件失败：文件未找到"
	puts "按任意键结束..."
	gets
	exit()
end
fin.each do |line|
	fileString += line
end
fin.close

messages = fileString.split('@@')
print "->发现", messages.count, "条信息\n"

index = 0
messages.each do |message|
	print "->", '#' , messages.index(message)+1, ' : ' 
	orders.push(Order.new(message.match(nameRegex)))
	print orders.last.name, ', ' 
	type = message.match(fruitTypeRegex)
	print fruitMap[type.to_s], ', ' 
	count = message.match(fruitCountRegex)
	print count, ', ' 
	unit = message.match(fruitUnitRegex)	
	print unit, ', ' 
	orders.last.addFruit(Fruit.new(type, count, unit))
	orders.last.dom = message.match(domRegex)
	print orders.last.dom, "\n" 
end
puts "----解析完成-----"



puts "正在生成orderlist.txt文件"
fout  = File.open(foutPath, "w+:utf-8")

#在控制台输出
orders.each do |order| 
	#fout.puts "\##{orders.index(order)}"
	fout.puts "#{order.name},#{order.dom},#{fruitMap[order.fruits[0].type.to_s]},#{order.fruits[0].count},#{order.fruits[0].unit}"
end
fout.close

puts "生成成功"
puts "orderlist.txt已被创建"
puts "按任意键结束..."
gets