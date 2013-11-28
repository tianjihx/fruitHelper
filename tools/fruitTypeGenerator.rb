require "pathname"
#Class Definition
class Fruit
	attr_accessor :outname, :namelist
	def initialize(names)
		@namelist = Array.new
		@namelist = names
		@outname = names[0]
	end

	def ToRegexUnit()
		regexStr = "(("
		regexStr += namelist.join(")|(")
		regexStr += "))" 
	end
end

#Global Variable
fruits = Array.new
fruitsRegexs = Array.new
#Run
dirPath = Pathname.new(File.dirname(__FILE__)).realpath
finPath = dirPath.to_s + "/" "fruittype.txt"
fin = File.open(finPath, "r:utf-8")
fin.each do |line|
	lineStr = line.to_s
	lineStr.delete!("\n")
	lineStr.delete!("\r")
	lineStr.lstrip!
	#puts lineStr
	fruits.push(Fruit.new(lineStr.split("/")))
	print "->", fruits.last.outname, "  <= ("
	for i in 0..fruits.last.namelist.count-1 do
		print fruits.last.namelist[i]
		if (i != fruits.last.namelist.count-1)
			print '/'
		end
	end
	print ")\n"
end
fin.close()

#输出正则
fregOutPath =  dirPath.to_s + "/../data/" "fruitTypeRegex.txt"
fregOut = File.open(fregOutPath,"w+:utf-8")
fregOut.print "("
fruits.each do |fruit|
	fruitsRegexs.push(fruit.ToRegexUnit)
end
fregOut.print fruitsRegexs.join("|")
fregOut.print ")"

#输出映射
fmapOutPath =  dirPath.to_s + "/../data/" "fruitTypeMap.rb"
fmapOut = File.open(fmapOutPath,"w+:utf-8")
fruits.each do |fruit|
	fruit.namelist.each do |name|
		fmapOut.puts "fruitMap[\"#{name}\"] = \"#{fruit.outname}\""
	end
	
end
