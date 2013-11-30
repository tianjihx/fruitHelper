#countFactory
def countNormalize(count)
	count.delete!("[斤根个只]")
	count.gsub!(/半/, ".5")
	count.gsub!(/一/, '1')
	count.gsub!(/二/, '2')
	count.gsub!(/两/, '2')
	count.gsub!(/三/, '3')
	count.gsub!(/四/, '4')
	count.gsub!(/五/, '5')
	count.gsub!(/六/, '6')
	count.gsub!(/七/, '7')
	count.gsub!(/八/, '8')
	count.gsub!(/九/, '9')
	return count
end

#domFactory
def domNormalize(dom)
	dom.sub!("博雅", "")
	dom.sub!(/(疏[桐通]?[园圆元]?)/, "疏")
	dom.sub!(/([静京景晶][园圆元]?)/, "静")
	dom.sub!(/(6[ABCabc])|([丹][枫风凤峰]?)/, "丹")
	dom.upcase!
	dom.gsub!(/[^疏静丹0-9A-Z]/, "")
	return dom
end
