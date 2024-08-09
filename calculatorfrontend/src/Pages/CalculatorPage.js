import SimpleOperation from "../Components/Operations/SimpleOperation";


function CalculatorPage() {
    return (
      <div className="Calculator">
            <SimpleOperation endpoint="Sum" operation="+" />
            <SimpleOperation endpoint="Subtraction" operation="-" />
            <SimpleOperation endpoint="Multiplication" operation="*" />
            <SimpleOperation endpoint="Division" operation="/" />
            <SimpleOperation endpoint="Root" operation="&radic;" />
            <SimpleOperation endpoint="Exponentiation" operation="^" />
  
      </div>
    );
  }
  
  export default CalculatorPage;
  