import hero from './hero.png'
import { Link } from 'react-router-dom'


const Hero = () => {
  return (
    <section id="hero">
    <div style={{
            display: 'flex',
            marginBottom: '5vw',
            marginTop: '5vw',
            marginLeft: '10vw'
        }}>
      <div>
        <h1>
          Calculation expressions
        </h1>

        <div>
          <Link
            to={"/calculation"}
          >
            Get Started
          </Link>
        </div>
      </div>
      <div>
        <img src={hero} alt="" style = {{width:200, height: 100, marginLeft: 10}}/>
      </div>
    </div>
  </section>
  )
}

export default Hero