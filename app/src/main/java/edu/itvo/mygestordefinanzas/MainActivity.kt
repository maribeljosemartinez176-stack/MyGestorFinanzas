package edu.itvo.mygestordefinanzas


import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import dagger.hilt.android.AndroidEntryPoint
import androidx.hilt.navigation.compose.hiltViewModel
import androidx.navigation.compose.rememberNavController
import edu.itvo.mygestordefinanzas.presentacion.MyGestorDeFinanzasApp
import edu.itvo.mygestordefinanzas.presentacion.navigation.MainNavGraph
import edu.itvo.mygestordefinanzas.presentacion.ui.screens.MainScreen
import edu.itvo.mygestordefinanzas.presentacion.viewmodel.MainViewModel

@AndroidEntryPoint
class MainActivity : ComponentActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)


        setContent {
            MyGestorDeFinanzasApp()
        }
    }
}

